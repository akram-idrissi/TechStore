using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TechStore.Models;
using TechStore.Data;

namespace TechStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IQueryable<Category> query = _context.Categories;
            IEnumerable<Category> categories = query.ToList();
            ViewBag.categories = categories;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
