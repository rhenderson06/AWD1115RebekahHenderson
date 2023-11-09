using Microsoft.AspNetCore.Mvc;
using SportsPro.Models;

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

            var product = context.Products.Find(id);

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
                    context.Products.Add(product);
                    msg = $"{product.Name} was added";
                }
                else
                {
                    context.Products.Update(product);
                    msg = $"{product.Name} was updated";
                }

                context.SaveChanges();
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
            var product = context.Products.Find(id);

            return View(product);
        }

        [HttpPost]
        public RedirectToActionResult Delete(Product product)
        {
            var p = context.Products.Find(product.ProductID);
            context.Products.Remove(p);
            context.SaveChanges();
            TempData["message"] = $"{p.Name} was deleted";
            return RedirectToAction("List");
        }

    }
}
