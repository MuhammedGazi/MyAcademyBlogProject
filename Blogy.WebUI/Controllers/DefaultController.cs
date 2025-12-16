using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(int id)
        {
            return View();
        }
    }
}
