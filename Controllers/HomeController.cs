using Microsoft.AspNetCore.Mvc;
namespace MyAspNetApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contects()
        {
            return View();
        }
        public IActionResult Contacts()
        {
            return View();
        }
    }
}
