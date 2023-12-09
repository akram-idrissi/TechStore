using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechStore.Data;
using TechStore.Models;

namespace TechStore.Controllers
{
    public class ProductController : Controller
    {
        private readonly DataContext _context;

        public ProductController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Product(int id)
        {
            var product = _context
                .products
                .Include(p => p.category)
                .FirstOrDefault(p => p.id == id);

            var similarProducts = _context
                .products
                .Where(
                    p => p.categoryID == product.categoryID && p.id != product.id
                )
                .OrderBy(x => Guid.NewGuid()) 
                .Take(4)
                .ToList();

            ViewBag.similars = similarProducts;
            return View(product);
        }
    }
}
