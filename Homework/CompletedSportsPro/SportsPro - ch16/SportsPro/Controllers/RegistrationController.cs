using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsPro.Models;
using Microsoft.AspNetCore.Authorization;
using SportsPro.Models.DataAccess;

namespace SportsPro.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RegistrationController : Controller
    {
        private Repository<Customer> customerData { get; set; }
        private Repository<Product> productData { get; set; }

        public RegistrationController(SportsProContext ctx)
        {
            customerData = new Repository<Customer>(ctx);
            productData = new Repository<Product>(ctx);
        }

        [HttpGet]
        public IActionResult Index()
        {
            RegistrationViewModel vm = new RegistrationViewModel();

            vm.Customers = customerData.List(new QueryOptions<Customer>
            {
                OrderBy = c => c.LastName
            }).ToList();

            return View(vm);
        }

        [HttpPost]
        public IActionResult List(RegistrationViewModel vm)
        {
            if (vm.Customer.CustomerID == 0)
            {
                TempData["message"] = "Select a customer";

                vm.Customers = customerData.List(new QueryOptions<Customer>
                { OrderBy = c => c.LastName }).ToList();
            }
            else
            {
                return RedirectToAction("List", new { id = vm.Customer.CustomerID });
            }
        }

        [HttpGet]
        public IActionResult List(int id)
        {
            RegistrationViewModel vm = new RegistrationViewModel();
            vm.Customer = customerData.Get(new QueryOptions<Customer>
            {
                Includes = "Products",
                Where = c => c.CustomerID == id
            })!;
            vm.Products = productData.List(new QueryOptions<Product>
            {
                OrderBy = p => p.Name
            }).ToList();

            vm.Customer.Products = vm.Customer.Products.OrderBy(productData => productData.Name).ToList();

            return View(vm);
        }

        [HttpPost]
        public IActionResult Filter(int customerID = 0)
        {
            return RedirectToAction("List", new { ID = customerID });
        }

        [HttpPost]
        public IActionResult Register(RegistrationViewModel model)
        {
            if (model.ProductID == 0)
            {
                TempData["message"] = "Select a product.";
            }
            else
            {
                Registration registration = new Registration
                {
                    CustomerID = model.CustomerID,
                    ProductID = model.ProductID,
                };
                data.Registrations.Insert(registration);

                try
                {
                    data.Save();
                }
                catch (DbUpdateException ex)
                {
                    string msg = (ex.InnerException == null) ? ex.Message : ex.InnerException.Message;
                    if (msg.Contains("duplicate key"))
                        TempData["message"] = "This product is already registered to database";
                    else
                        TempData["message"] = $"Error accessing database: {msg}";
                }
            }
            return RedirectToAction("List", new { ID = model.CustomerID });
        }

        [HttpPost] 
        public IActionResult Delete(int customerID, int productID)
        {
            Registration registration = new Registration
            {
                CustomerID = customerID,
                ProductID = productID
            };
            data.Registrations.Delete(registration);
            data.Save();
            return RedirectToAction("List", new { ID = customerID });
        }
    }
}
