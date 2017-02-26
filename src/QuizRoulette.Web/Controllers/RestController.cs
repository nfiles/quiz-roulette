using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace QuizRoulette.Web.Controllers
{
    // [Route("api/[controller]")]
    public abstract class RestController<TEntity, TKey> : Controller
        where TKey : new()
        where TEntity : class, new()
    {
        protected readonly DbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        private readonly Expression<Func<TEntity, TKey>> _identifierExpression;
        private readonly Func<TEntity, TKey> _getIdentifier;
        private readonly MemberExpression _identifierMember;

        public RestController(
            DbContext context,
            Expression<Func<TEntity, TKey>> identifierProp
        )
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            if (identifierProp == null)
            {
                throw new ArgumentNullException(nameof(identifierProp));
            }

            _context = context;
            _dbSet = context.Set<TEntity>();
            _identifierExpression = identifierProp;
            _getIdentifier = _identifierExpression.Compile();
            _identifierMember = identifierProp.Body as MemberExpression;

            if (_identifierMember == null)
            {
                throw new ArgumentException($"Must be a member of ${typeof(TEntity).FullName}.", nameof(identifierProp));
            }
        }

        [HttpGet]
        public virtual async Task<IActionResult> GetAll(CancellationToken token)
        {
            return Ok(await _dbSet.ToListAsync(token));
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Get([FromRoute]TKey id, CancellationToken token)
        {
            var item = await _dbSet.FirstOrDefaultAsync(CreateIdentifierLambda(id), token);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]TEntity model, CancellationToken token)
        {
            _dbSet.Add(model);
            await _context.SaveChangesAsync(token);

            return CreatedAtAction(nameof(Get), new { id = _getIdentifier(model) }, model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute]TKey id, [FromBody]TEntity model, CancellationToken token)
        {
            bool itemExists = await _dbSet.AnyAsync(CreateIdentifierLambda(id), token);
            if (!itemExists)
            {
                return NotFound();
            }

            _dbSet.Update(model);
            await _context.SaveChangesAsync(token);

            return Ok(model);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute]TKey id, CancellationToken token)
        {
            var item = await _dbSet.FirstOrDefaultAsync(CreateIdentifierLambda(id), token);
            if (item == null)
            {
                return NotFound();
            }

            _context.Remove(item);
            await _context.SaveChangesAsync(token);

            return Ok();
        }

        private Expression<Func<TEntity, bool>> CreateIdentifierLambda(TKey id)
        {
            // ref: http://stackoverflow.com/a/24188794/2548291
            ParameterExpression entityParam = Expression.Parameter(typeof(TEntity), "entity");

            Expression property = Expression.Property(entityParam, _identifierMember.Member.Name);
            Expression<Func<TKey>> idLambda = () => id;
            Expression searchExpr = Expression.Equal(property, idLambda.Body);

            return Expression.Lambda<Func<TEntity, bool>>(searchExpr, entityParam);
        }
    }
}
