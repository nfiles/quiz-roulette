using System;
using Microsoft.AspNetCore.Mvc;
using QuizRoulette.Database;

namespace QuizRoulette.Web.ApiControllers
{
    [Route("api/[controller]")]
    public class QuizController : RestController<Quiz, Guid>
    {
        public QuizController(QuizDbContext context)
            : base(context, q => q.Identifier) { }
    }
}
