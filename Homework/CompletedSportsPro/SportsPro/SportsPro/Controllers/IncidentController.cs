using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsPro.Models;
using SportsPro.ViewModels;

namespace SportsPro.Controllers
{
    public class IncidentController : Controller
    {
        private SportsProContext context { get; set; }

        public IncidentController(SportsProContext ctx)
        {
            context = ctx;
        }

        [Route("[controller]s")]
        public IActionResult List(string filter = "all")
        {
            IncidentListViewModel model = new IncidentListViewModel 
            {
                Filter = filter
            };

            var options = new QueryOptions<Incident>
            {
                Includes = "Customer, Product",
                OrderBy = i => i.DateOpened
            };

            if (filter == "unassigned")
            {
                options.Where = i => i.TechnicianID == null;
            }

            if (filter == "open")
            {
                options.Where = i => i.DateClosed == null;
            }

            //List<Incident> incidents = context.Incidents.Include(c => c.Customer)
            //                                            .Include(p => p.Product)
            //                                            .OrderBy(i => i.DateOpened) .ToList();
            IEnumerable<Incident> incidents = context.Incidents.List(options);
            model.Incidents = incidents;

            return View(incidents);
        }

        private IncidentViewModel GetViewModel()
        {
            IncidentViewModel model = new IncidentViewModel
            {
                Customers = context.Customers.List(new QueryOptions<Customer>
                {
                    OrderBy = c => c.FirstName
                }),
                Products = context.Products.List(new QueryOptions<Product>
                {
                    OrderBy = c => c.Name
                }),
                Technicians = context.Technicians.List(new QueryOptions<Technician>
                {
                    OrderBy = c => c.Name
                })
            };

            return model;
        }

        public IActionResult Filter(string id)
        {
            return RedirectToAction("List", new { Filter = id });
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
            IncidentViewModel model = GetViewModel();
            model.Incident = new Incident();
            model.Action = "Add";
            return View("AddEdit", model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            IncidentViewModel model = GetViewModel();
            var incident = context.Incidents.Find(id);
            model.Incident = incident;
            model.Action = "Edit";

            return View("AddEdit", model);
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
                IncidentViewModel model = GetViewModel();
                model.Incident = incident;

                if (incident.IncidentID == 0)
                {
                    model.Action = "Add";
                }
                else
                {
                    model.Action = "Edit";
                }

                return View("AddEdit", model);
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
