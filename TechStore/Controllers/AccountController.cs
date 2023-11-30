using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TechStore.Models;
using Microsoft.EntityFrameworkCore;
using TechStore.Data;


namespace TechStore.Controllers
{
    public class AccountController : Controller
    {
        

        private readonly DataContext _context;

        public AccountController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Logout()
        {
            return View();
        }

        public async Task<ActionResult<List<User>>> getClients()
        {
            return await _context.users.ToListAsync();
        }

        public async Task<ActionResult<User>?> getClient(int id)
        {
            var client = await _context.users.FindAsync(id);

            if (client is null)
                return null;

            return client;
        }

        public async void addClient(User client)
        {
            _context.users.Add(client);
            await _context.SaveChangesAsync();
        }

        public async void removeClient(int id)
        {
            var client = await _context.users.FindAsync(id);

            if (client is not null)
            {
                _context.users.Remove(client);
                await _context.SaveChangesAsync();
            }
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                
                return RedirectToAction("Register");
            }
            else
            {
                return View();
            }
        }

    }
}
