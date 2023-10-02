using Microsoft.AspNetCore.Mvc;
using MyWebsite7.Models;
using System.Diagnostics;

namespace MyWebsite7.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            var contacts = new Dictionary<string, string>
            {
                { "Phone", "334-456-9876" },
                { "Email", "email@gmail.com" },
                { "Facebook", "facebook.com/mywebsite" }
            };

            return View(contacts);
        }
    }
}