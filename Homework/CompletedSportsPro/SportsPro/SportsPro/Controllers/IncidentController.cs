using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsPro.Models;

namespace SportsPro.Controllers
{
    public class IncidentController : Controller
    {
        private SportsProContext context { get; set; }

        public IncidentController(SportsProContext ctx)
        {
            context = ctx;
        }

        public ActionResult List()
        {
            List<Incident> incidents = context.Incidents.Include(c => c.Customer)
                                                        .Include(p => p.Product)
                                                        .OrderBy(i => i.DateOpened) .ToList();

            return View(incidents);
        }

        public void StoreListsInViewBag()
        {
            ViewBag.Customers = context.Customers.OrderBy(c => c.FirstName);
            ViewBag.Products = context.Products.OrderBy(p => p.Name).ToList();
            ViewBag.Technicians = context.Technicians.OrderBy(t => t.Name).ToList();
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";

            StoreListsInViewBag();

            return View("AddEdit", new Incident());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";

            StoreListsInViewBag();

            var incident = context.Incidents.Find(id);

            return View("AddEdit", incident);
        }

        [HttpPost]
        public IActionResult Save(Incident incident)
        {
            if (ModelState.IsValid)
            {
                if (incident.IncidentID == 0)
                {
                    context.Incidents.Add(incident);
                }
                else
                {
                    context.Incidents.Update(incident);
                }

                context.SaveChanges();
                return RedirectToAction("List");
            }
            else
            {
                if (incident.IncidentID == 0)
                {
                    ViewBag.Action = "Add";
                }
                else
                {
                    ViewBag.Action = "Edit";
                }

                return View(incident);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var incident = context.Incidents.Find(id);

            return View(incident);
        }

        [HttpPost]
        public IActionResult Delete(Incident incident)
        {
            context.Incidents.Remove(incident);
            context.SaveChanges();

            return RedirectToAction("List");
        }

    }
}
