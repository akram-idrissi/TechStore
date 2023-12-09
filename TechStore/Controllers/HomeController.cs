using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechStore.Data;
using TechStore.Models;

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

            var allProducts = _context.products.Include(p => p.category).ToList();

            var random = new Random();
            var shuffledProducts = allProducts.OrderBy(x => random.Next()).ToList();

            var numberOfFeaturedProducts = 5; 
            var featuredProducts = shuffledProducts.Take(numberOfFeaturedProducts).ToList();

            ViewBag.featuredProducts = featuredProducts;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(
                new ErrorViewModel
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
                }
            );
        }
    }
}
