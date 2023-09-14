using ContactMgr4_1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ContactMgr4_1.Controllers
{
    public class HomeController : Controller
    {
        private ContactContextModel context { get; set; }
        public HomeController(ContactContextModel ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            var contacts = context.Contacts.Include(c => c.Category).OrderBy(c => c.FirstName).ToList();
            return View(contacts);
        }

    }
}