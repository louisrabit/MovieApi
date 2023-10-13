using System.ComponentModel.DataAnnotations;

namespace MovieApi.Models;

public class Address
{
    [Key]
    [Required]
    public int Id { get; set; }
    public string Logradouro { get; set; }
    public int Number { get; set; }

    // Nao pomos o ID porque o Address nao precisa de ter cinema 
     public virtual Cinema Cinema { get; set; }



  
}
