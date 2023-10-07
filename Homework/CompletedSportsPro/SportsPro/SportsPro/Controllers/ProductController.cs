﻿using Microsoft.AspNetCore.Mvc;
using SportsPro.Models;

namespace SportsPro.Controllers
{
    public class ProductController : Controller
    {
        private SportsProContext context { get; set; }

        public ProductController(SportsProContext ctx) 
        {
            context = ctx;
        }

        public ActionResult List()
        {
            List<Product> products = context.Products.OrderBy(p => p.Name).ToList();

            return View(products);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";

            return View("AddEdit", new Product());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";

            var product = context.Products.Find(id);

            return View("AddEdit", product);
        }

        [HttpPost]
        public IActionResult Save(Product product)
        {
            if (ModelState.IsValid)
            {
                if (product.ProductID == 0)
                {
                    context.Products.Add(product);
                }
                else
                {
                    context.Products.Update(product);
                }

                context.SaveChanges();
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
        public IActionResult Delete(int id)
        {
            var product = context.Products.Find(id);

            return View(product);
        }

        [HttpPost]
        public IActionResult Delete(Product product)
        {
            context.Products.Remove(product);
            context.SaveChanges();

            return RedirectToAction("List");
        }

    }
}
