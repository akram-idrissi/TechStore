using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TechStore.Data;
using TechStore.Models;

namespace TechStore.Controllers
{
    public class CategoryController : Controller
    {
        private readonly DataContext _context;
        //private readonly ILogger<CategoryController> _logger;

        public CategoryController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Category()
        {
            IQueryable<Category> query = _context.Categories;
            IEnumerable<Category> categories = query.ToList();
            ViewBag.categories = categories;
            return View();
        }

        public IActionResult Categories(string nom)
        {
            IQueryable<Category> query = _context.Categories;
            IEnumerable<Category> categories = query.ToList();

            var category = _context.Categories.Where(c => c.Nom == nom).FirstOrDefault();
            var products = _context.products.Where(p => p.categoryID == category.id).ToList();

            ViewBag.categories = categories;
            ViewBag.categoryName = nom;
            ViewBag.products = products;
            return View("Category");
        }
    }
}
