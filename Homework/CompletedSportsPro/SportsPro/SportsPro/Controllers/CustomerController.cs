using Microsoft.AspNetCore.Mvc;
using SportsPro.DataLayer;
using SportsPro.Models;

namespace SportsPro.Controllers
{
    public class CustomerController : Controller
    {
        private SportsProUnit data { get; set; }

        public CustomerController(SportsProContext ctx)
        {
            data = new SportsProUnit(ctx);
        }

        [Route("[controller]s")]
        public ActionResult List()
        {
            var customers = data.Customers.List(new QueryOptions<Customer>
            {
                OrderBy = c => c.LastName
            }) ;

            return View(customers);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";

            ViewBag.Countries = GetCountryList();

            return View("AddEdit", new Customer());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";

            ViewBag.Countries = GetCountryList();

            var customer = data.Customers.Get(id);

            return View("AddEdit", customer);
        }

        [HttpPost]
        public IActionResult Save(Customer customer)
        {
            if (customer.CountryID == "XX")
            {
                ModelState.AddModelError(nameof(Customer.CountryID), "Required.");
            }

            if (customer.CustomerID == 0 && TempData["okEmail"] == null)
            {
                string msg = Check.EmailExists(data.Customers, customer.Email);
                if (!string.IsNullOrEmpty(msg))
                {
                    ModelState.AddModelError(nameof(Customer.Email), msg);
                }
            }

            if (ModelState.IsValid)
            {
                if (ViewBag.Action == "Add")
                {
                    data.Customers.Insert(customer);
                }
                else
                {
                    data.Customers.Update(customer);
                }

                data.Save();
                return RedirectToAction("List");
            }
            else
            {
                if (customer.CustomerID == 0)
                {
                    ViewBag.Action = "Add";
                }
                else
                {
                    ViewBag.Action = "Edit";
                }

                return View("AddEdit", customer);
            }
        }

        [HttpGet]
        public IActionResult Delete(Customer customer)
        {
            data.Customers.Delete(customer);
            data.Save();
            return RedirectToAction("List");
        }

        IEnumerable<Country> GetCountryList() =>
            data.Countries.List(new QueryOptions<Country> { OrderBy = c => c.Name });

    }
}
