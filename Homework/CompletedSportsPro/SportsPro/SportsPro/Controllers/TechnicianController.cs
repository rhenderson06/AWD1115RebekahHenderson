﻿using Microsoft.AspNetCore.Mvc;
using SportsPro.DataLayer;
using SportsPro.Models;

namespace SportsPro.Controllers
{
    public class TechnicianController : Controller
    {
        private Repository<Technician> data { get; set; }

        public TechnicianController(SportsProContext ctx)
        {
            data = new Repository<Technician>(ctx);
        }

        [Route("[controller]s")]
        public ActionResult List()
        {
            var techs = this.data.List(new QueryOptions<Technician>
            {
                OrderBy = t => t.Name
            });

            return View(techs);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";

            return View("AddEdit", new Technician());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";

            var tech = data.Get(id);

            return View("AddEdit", tech);
        }

        [HttpPost]
        public IActionResult Save(Technician tech)
        {
            if (ModelState.IsValid)
            {
                if (tech.TechnicianID == 0)
                {
                    data.Insert(tech);
                }
                else
                {
                    data.Update(tech);
                }

                data.Save();
                return RedirectToAction("List");
            }
            else
            {
                if (tech.TechnicianID == 0)
                {
                    ViewBag.Action = "Add";
                }
                else
                {
                    ViewBag.Action = "Edit";
                }

                return View(tech);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var tech = data.Get(id);

            return View(tech);
        }

        [HttpPost]
        public IActionResult Delete(Technician tech)
        {
            data.Delete(tech);
            data.Save();

            return RedirectToAction("List");
        }

    }
}
