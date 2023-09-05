using Microsoft.AspNetCore.Mvc;
using PriceQuotation2_1.Models;
using System.Diagnostics;

namespace PriceQuotation2_1.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Discount = 0.0;
            ViewBag.Total = 0.0;
            return View();
        }

        [HttpPost]
        public IActionResult Index(Quotation quote)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Discount = quote.CalculateDiscount();
                ViewBag.Total = quote.CalculateTotal();
            }
            else
            {
                ViewBag.Discount = 0.0;
                ViewBag.Total = 0.0;
            }

            return View(quote);
        }
    }
}