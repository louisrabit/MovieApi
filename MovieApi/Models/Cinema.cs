using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace MovieApi.Models;

public class Cinema
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo nome é obrigatório.")]
    public string Nome { get; set; }



    //Criar o AdressID para relacionar o Address e o cinema 
    public int AddressId { get; set; }
    // Precisamos de dizer que o Address e o Id possuem uma relaçao de 1 para 1
    // Como é que entity vai perceber isso ?

    public virtual Address Address { get; set; }  //vai ter uma propriedade virtual -- > Explicita que o Cinema Tera 1 Address

    public virtual ICollection<Session> Session { get; set; }


}
