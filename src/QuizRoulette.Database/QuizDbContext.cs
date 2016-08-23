using Microsoft.EntityFrameworkCore;

namespace QuizRoulette.Database
{
    public class QuizDbContext : DbContext
    {
        public QuizDbContext() : base() { }
        public QuizDbContext(DbContextOptions options)
            : base(options)
        { }
    }
}