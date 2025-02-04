using System.ComponentModel.DataAnnotations;

namespace ContactApp.Models;

public class ContactModel
{
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    [Required, EmailAddress]
    public string Email { get; set; }
    
    [Required, Phone]
    public string Phone { get; set; }

    public ContactModel() { }
    
    public ContactModel(int id, string name, string email, string phone)
    {
        Id = id;
        Name = name;
        Email = email;
        Phone = phone;
    }
}