using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
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

        public IActionResult Product()
        {
            return View();
        }

        public IActionResult ProductDetail(int id)
        {
            var product = _context.products.Where(p => p.id == id).FirstOrDefault();
            return View(product);
        }
    }
}
