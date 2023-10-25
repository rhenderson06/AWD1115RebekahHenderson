using Microsoft.AspNetCore.Mvc;
using QuarterlySalesApp11.Models;
using QuarterlySalesApp11.Models.Validation;

namespace QuarterlySalesApp11.Controllers
{
    public class SaleController : Controller
    {
        private SalesContext context;
        public SaleController(SalesContext ctx) => context = ctx;

        public IActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Employees = context.Employees.OrderBy(e => e.FirstName).ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Add(Sale sale)
        {
            //server side checks
            string msg = Validate.CheckSales(context, sale);
            if (!string.IsNullOrEmpty(msg))
            {
                ModelState.AddModelError(nameof(sale.EmployeeID), msg);
            }

            if (ModelState.IsValid)
            {
                context.Sales.Add(sale);
                context.SaveChanges();

                TempData["message"] = "Sale added to database.";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Employees = context.Employees.OrderBy(e => e.FirstName).ToList();

                return View();
            }
        }
    }
}
