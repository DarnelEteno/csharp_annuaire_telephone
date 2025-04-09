using System.ComponentModel.DataAnnotations;

namespace AnnuaireTelephone.Models;

public class Client
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Matricule { get; set; }

    [Required]
    public string Nom { get; set; }

    [Required]
    public string Prenom { get; set; }

    public ICollection<Telephone> Telephones { get; set; }
}