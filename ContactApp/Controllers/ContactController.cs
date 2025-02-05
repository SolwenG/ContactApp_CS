using ContactApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContactApp.Controllers
{
    public class ContactController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContactController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string? searchValue = null)
        {
            var contacts = string.IsNullOrEmpty(searchValue)
                ? await _context.Contacts.ToListAsync()
                : await _context.Contacts.Where(c => c.Name.ToLower().Contains(searchValue.ToLower())).ToListAsync();

            return View(contacts);
        }

        [HttpPost]
        public async Task<IActionResult> AddContact(ContactModel contact)
        {
            if (ModelState.IsValid)
            {
                _context.Contacts.Add(contact);
                await _context.SaveChangesAsync();

                TempData["Message"] = "Contact ajouté avec succès !";
                return RedirectToAction("Index");
            }

            return View("Index", await _context.Contacts.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }

            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();

            TempData["Message"] = "Contact supprimé avec succès !";
            return RedirectToAction("Index");
        }
    }
}