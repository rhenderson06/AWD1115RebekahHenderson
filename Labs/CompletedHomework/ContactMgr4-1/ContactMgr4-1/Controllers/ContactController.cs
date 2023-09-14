using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContactMgr4_1.Models;

namespace ContactMgr4_1.Controllers
{
    public class ContactController : Controller
    { 
        private ContactContextModel context { get; set; }
        public ContactController(ContactContextModel ctx)
        {
            context = ctx;
        }

        public IActionResult Details(int id)
        {
            var contact = context.Contacts.Include(c => c.Category).FirstOrDefault(c => c.ContactId == id);
            return View(contact);
        }

        // add new record
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add"; 
            ViewBag.Categories = context.Categories.OrderBy(c => c.Name).ToList();

            return View("Edit", new ContactModel());
        }

        //attempt to update existing record
        [HttpGet] 
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Categories = context.Categories.OrderBy(c => c.Name).ToList();

            var contact = context.Contacts.Include(c => c.Category).FirstOrDefault(c => c.ContactId == id);

            return View(contact);
        }

        [HttpPost]
        public IActionResult Edit(ContactModel contact)
        {
            //if no ContactId then "Add"
            //if is ContactId then "Edit"
            string action = (contact.ContactId == 0) ? "Add" : "Edit";

            //validate all required fields have been filled in
            if (ModelState.IsValid)
            {
                if (action == "Add")
                {
                    contact.DateAdded = DateTime.Now;
                    context.Contacts.Add(contact);
                }
                else // action == "Edit"
                {
                    context.Contacts.Update(contact);
                }
                //save changes to database
                context.SaveChanges();

                //redirect to home page
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action = action;
                ViewBag.Categories = context.Categories.OrderBy(c => c.Name).ToList();

                return View(contact);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var contact = context.Contacts.Include(c => c.Category).FirstOrDefault(c => c.ContactId == id);

            return View(contact);
        }

        [HttpPost]
        public IActionResult Delete(ContactModel contact)
        {
            context.Contacts.Remove(contact);
            context.SaveChanges(true);

            return RedirectToAction("Index", "Home");
        }
    }
}
