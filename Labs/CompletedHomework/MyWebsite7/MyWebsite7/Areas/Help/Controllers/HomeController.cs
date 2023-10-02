using Microsoft.AspNetCore.Mvc;

namespace MyWebsite7.Areas.Help.Controllers
{
    [Area("Help")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
