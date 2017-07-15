using Microsoft.AspNetCore.Mvc;

namespace QuizRoulette.Web.Controllers
{
    public class AppController : Controller
    {
        [Route("[controller]/{*catchall}")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
