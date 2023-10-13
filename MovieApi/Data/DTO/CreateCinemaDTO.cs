using System.ComponentModel.DataAnnotations;

namespace MovieApi.Data.DTO;

public class CreateCinemaDTO
{
    [Required(ErrorMessage = "O campo nome é obrigatório.")]
    public string Nome { get; set; }



    public int AddressId { get; set; }
}
