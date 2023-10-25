using Microsoft.AspNetCore.Mvc;
using QuarterlySalesApp11.Models;
using QuarterlySalesApp11.Models.Validation;

namespace QuarterlySalesApp11.Controllers
{
    public class EmployeeController : Controller
    {
        private SalesContext context;

        public EmployeeController(SalesContext ctx) => context = ctx;

        public IActionResult Index() => RedirectToAction("Index", "Home");

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Employees = context.Employees.OrderBy(e => e.FirstName).ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Add(Employee employee)
        {
            string msg = Validate.CheckEmployee(context, employee);
            if (!string.IsNullOrEmpty(msg))
            {
                ModelState.AddModelError(nameof(Employee.DOB), msg);
            }

            msg = Validate.CheckManager(context, employee);
            if (!string.IsNullOrEmpty(msg))
            {
                ModelState.AddModelError(nameof(Employee.ManagerID), msg);
            }

            if (ModelState.IsValid)
            {
                context.Employees.Add(employee);
                context.SaveChanges();

                TempData["message"] = $"Employee {employee.FullName} added to database.";
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