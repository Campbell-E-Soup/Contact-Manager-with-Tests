using Contact_Manager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Contact_Manager.Controllers
{
    public class HomeController : Controller
    {
        private IRepository<Contact> data { get; set; }
        public HomeController(IRepository<Contact> repo) => data = repo; 
        public IActionResult Index()
        {
            var options = new QueryOptions<Contact>
            {
                OrderBy = c => c.FirstName,
                Includes = "Category"
            };
            var contacts = data.List(options);
            return View(contacts);
        }
    }
}
