using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnnuaireTelephone.Models;

public class Telephone
{
    [Key]
    public int Id { get; set; }

    [Required]
    [RegularExpression(@"^(77|78|76|70)\d{7}$", ErrorMessage = "Numéro invalide")]
    public string Numero { get; set; }

    public Operateur Operateur => GetOperateur();

    [ForeignKey("Client")]
    public int ClientId { get; set; }

    public Client Client { get; set; }

    private Operateur GetOperateur()
    {
   
        if (Numero.StartsWith("77") || Numero.StartsWith("78")) return Operateur.Orange;
        if (Numero.StartsWith("76")) return Operateur.Yas;
        if (Numero.StartsWith("70")) return Operateur.Expresso;
        return Operateur.Inconnu;
    }
}