using Contact_Manager.Models;
using Microsoft.AspNetCore.Mvc;

namespace Contact_Manager.Controllers
{
    public class ContactController : Controller
    {
        private IRepository<Contact> contactsRepo { get; set; }
        private IRepository<Category> catsRepo { get; set; }
        public ContactController(IRepository<Contact> con, IRepository<Category> cat)
        {
            contactsRepo = con;
            catsRepo = cat;
        }

        [HttpGet]
        public IActionResult Add()
        {
            var options = new QueryOptions<Category>()
            {
                OrderBy = c => c.CategoryID
            };
            ViewBag.Action = "Add";
			ViewBag.Categories = catsRepo.List(options);
			return View("Edit", new Contact());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var options = new QueryOptions<Category>()
            {
                OrderBy = c => c.CategoryID
            };
            ViewBag.Action = "Edit";
			ViewBag.Categories = catsRepo.List(options);
			var contact = contactsRepo.Get(id);
            return View(contact);
        }

        [HttpPost]
        public IActionResult Edit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                if (contact.ContactID == 0) { contactsRepo.Insert(contact); }
                else { contactsRepo.Update(contact); }
                contactsRepo.Save();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                var options = new QueryOptions<Category>()
                {
                    OrderBy = c => c.CategoryID
                };
                ViewBag.Action = (contact.ContactID == 0) ? "Add" : "Edit";
				ViewBag.Categories = catsRepo.List(options);
				return View(contact);
            }
        }

        [HttpGet] 
        public IActionResult Delete(int id)
        {
            var contact = contactsRepo.Get(id);
            return View(contact);
        }
        [HttpPost]
        public IActionResult Delete(Contact contact)
        {
            contactsRepo.Delete(contact);
            contactsRepo.Save();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Details(int id)
        {
            var contact = contactsRepo.Get(id);
            if (contact != null)
            {
                ViewBag.CategoryName = catsRepo.Get((int)contact.CategoryID).Name;
            }
            else
            {
                ViewBag.CategoryName = "";
            }
            
			return View(contact);
        }
    }
}
