using Microsoft.AspNetCore.Mvc;

namespace BestPracticeDirectory.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
