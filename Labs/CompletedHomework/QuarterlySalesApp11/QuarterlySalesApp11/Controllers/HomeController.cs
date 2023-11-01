using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuarterlySalesApp11.Models;

namespace QuarterlySalesApp11.Controllers
{
    public class HomeController : Controller
    {
        private SalesContext context { get; set; }

        public HomeController(SalesContext ctx)
        {
            context = ctx;
        }

        [HttpGet]
        public IActionResult Index(int id)
        {
            IQueryable<Sale> query = context.Sales
                                            .Include(s => s.Employee)
                                            .OrderBy(s => s.Year);

            if (id > 0)
            {
                query = query.Where(s => s.EmployeeID == id);
            }

            var vm = new SalesListViewModel
            {
                Sales = query.ToList(),
                Employees = context.Employees
                                   .OrderBy(e => e.FirstName)
                                   .ToList(),
                EmployeeID = id
            };

            return View(vm);
        }

        [HttpPost]
        public RedirectToActionResult Index(Employee employee)
        {
            if (employee.EmployeeID > 0)
            {
                return RedirectToAction("Index", new { id = employee.EmployeeID });
            }
            else
            {
                return RedirectToAction("Index", new { id = "" });
            }
        }
        //private SalesContext context { get; set; }
        //public HomeController(SalesContext ctx) => context = ctx;

        //[HttpGet]
        //public IActionResult Index(int id)
        //{
        //    IQueryable<Sale> query = context.Sales.Include(s => s.Employee).OrderBy(s => s.Year);

        //    if (id > 0)
        //    {
        //        query = query.Where(s => s.EmployeeID == id);
        //    }

        //    var vm = new SalesListViewModel
        //    {
        //        Sales = query.ToList(),
        //        Employees = context.Employees.OrderBy(e => e.FirstName).ToList(),
        //        EmployeeID = id
        //    };

        //    return View(vm);
        //}

        //[HttpPost]
        //public RedirectToActionResult Index(Employee employee)
        //{
        //    if (employee.EmployeeID > 0)
        //    {
        //        return RedirectToAction("Index", new { id = employee.EmployeeID });
        //    }
        //    else
        //    {
        //        return RedirectToAction("Index", new { id = "" });
        //    }
        //}
    }
}