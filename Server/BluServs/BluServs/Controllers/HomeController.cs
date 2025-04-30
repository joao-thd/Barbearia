using Microsoft.AspNetCore.Mvc;

namespace BluServs.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
