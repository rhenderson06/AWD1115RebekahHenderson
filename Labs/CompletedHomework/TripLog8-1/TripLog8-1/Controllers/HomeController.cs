using Microsoft.AspNetCore.Mvc;
using TripLog8_1.Models;

namespace TripLog8_1.Controllers
{
    public class HomeController : Controller
    {
        private TripLogContext context { get; set; }
        
        public HomeController(TripLogContext ctx) 
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            var trips = context?.Trips.OrderBy(t => t.StartDate).ToList();

            return View(trips);
        }
    }
}