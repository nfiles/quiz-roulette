#if APP
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace QuizRoulette.Database
{
    public class Program
    {
        public static void Main(string[] args) { }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<QuizDbContext>(options =>
            {
                options.UseNpgsql("User ID=quizadmin;Password=Qu1zP@ssw0rd!;Host=localhost;Port=5432;Database=quizdb;");
            });
        }
    }
}
#endif
