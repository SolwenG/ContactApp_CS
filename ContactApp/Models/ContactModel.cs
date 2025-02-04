using System.ComponentModel.DataAnnotations;

namespace ContactApp.Models;

public class ContactModel
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Le nom est obligatoire")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "L'adresse mail est obligatoire"), EmailAddress(ErrorMessage = "L'adresse mail n'est pas valide")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "Le numéro de téléphone est obligatoire"), Phone(ErrorMessage = "Le numéro de téléphone doit contenir que des chiffres")]
    [StringLength(10)]
    [MinLength(10, ErrorMessage = "Le numéro de téléphone doit contenir 10 chiffres")]
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