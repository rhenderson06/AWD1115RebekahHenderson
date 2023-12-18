using Microsoft.AspNetCore.Mvc;
using SportsPro.Models;
using SportsPro.Models.DataAccess;

namespace SportsPro.Controllers
{
    public class ProductController : Controller
    {
        private Repository<Product> data { get; set; }

        public ProductController(SportsProContext ctx) 
        {
            data = new Repository<Product>(ctx);
        }

        [Route("[controller]s")]
        public ViewResult List()
        {
            //List<Product> products = context.Products.OrderBy(p => p.Name).ToList();
            var products = this.data.List(new QueryOptions<Product>
            {
                OrderBy = p => p.ReleaseDate
            });

            return View(products);
        }

        [HttpGet]
        public ViewResult Add()
        {
            ViewBag.Action = "Add";

            return View("AddEdit", new Product());
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            ViewBag.Action = "Edit";

            var product = data.Get(id);

            return View("AddEdit", product);
        }

        [HttpPost]
        public IActionResult Save(Product product)
        {
            string msg;
            if (ModelState.IsValid)
            {
                if (product.ProductID == 0)
                {
                    data.Insert(product);
                    msg = $"{product.Name} was added";
                }
                else
                {
                    data.Update(product);
                    msg = $"{product.Name} was updated";
                }

                data.Save();
                TempData["message"] = msg;
                return RedirectToAction("List");
            }
            else
            {
                if (product.ProductID == 0)
                {
                    ViewBag.Action = "Add";
                }
                else
                {
                    ViewBag.Action = "Edit";
                }

                return View(product);
            }
        }

        [HttpGet]
        public ViewResult Delete(int id)
        {
            var product = data.Get(id);

            return View(product);
        }

        [HttpPost]
        public RedirectToActionResult Delete(Product product)
        {
            var p = data.Get(product.ProductID);
            data.Delete(p);
            data.Save();
            TempData["message"] = $"{p.Name} was deleted";
            return RedirectToAction("List");
        }

    }
}
