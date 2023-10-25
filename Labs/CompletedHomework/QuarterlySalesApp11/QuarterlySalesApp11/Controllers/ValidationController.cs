using Microsoft.AspNetCore.Mvc;
using QuarterlySalesApp11.Models;
using QuarterlySalesApp11.Models.Validation;

namespace QuarterlySalesApp11.Controllers
{
    public class ValidationController : Controller
    {
        private SalesContext context;

        public ValidationController(SalesContext ctx) => context = ctx;

        public JsonResult CheckEmployee(DateTime dob, string firstname, string lastname)
        {
            var employee = new Employee
            {
                FirstName = firstname,
                LastName = lastname,
                DOB = dob
            };

            string msg = Validate.CheckEmployee(context, employee);
            if (string.IsNullOrEmpty(msg))
            {
                return Json(true);
            }
            else
            {
                return Json(msg);
            }
        }

        public JsonResult CheckManager(int managerId, string firstname, string lastname, DateTime dob)
        {
            var employee = new Employee
            {
                FirstName = firstname,
                LastName = lastname,
                DOB = dob,
                ManagerID = managerId
            };

            string msg = Validate.CheckManager(context, employee);
            if (string.IsNullOrEmpty(msg))
            {
                return Json(true);
            }
            else
            {
                return Json(msg);
            }
        }

        public JsonResult CheckSales(int quarter, int year, int employeeId)
        {
            var sale = new Sale
            {
                Quarter = quarter,
                Year = year,
                EmployeeID = employeeId
            };

            string msg = Validate.CheckSales(context, sale);
            if (string.IsNullOrEmpty(msg))
            {
                return Json(true);
            }
            else
            {
                return Json(msg);
            }
        }
    }
}
