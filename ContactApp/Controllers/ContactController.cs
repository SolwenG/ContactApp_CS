using ContactApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContactApp.Controllers;

[ApiController]
[Route("[controller]")]
public class ContactController : Controller
{
    private static readonly List<ContactModel> Contacts =
    [
        new ContactModel(1, "Solene", "example@gmail.com", "1234567890")
    ];

    [HttpGet]
    public IActionResult Index(string? searchValue = null)
    {
        var contacts = string.IsNullOrEmpty(searchValue)
            ? Contacts
            : Contacts.Where(contact => contact.Name.Contains(searchValue, StringComparison.OrdinalIgnoreCase))
                .ToList();

        return View(contacts);
    }

    [HttpPost]
    public IActionResult AddContact([FromForm] ContactModel contact)
    {
        int Id = Contacts.Count + 1;
        contact.Id = Id;
        Contacts.Add(contact);

        return RedirectToAction("Index");
    }

    [HttpPost]
    [Route("delete/{id:int}")]
    public IActionResult RemoveContact(int id)
    {
        var existingContacts = Contacts.FirstOrDefault(contact => contact.Id == id);
        Console.WriteLine(existingContacts);
        if (existingContacts == null)
        {
            return NotFound();
        }

        Contacts.Remove(existingContacts);

        return RedirectToAction("Index");
    }
}