using System.ComponentModel.DataAnnotations;

namespace MovieApi.Data.DTO;

public class ReadCinemaDTO
{
  
    public int Id { get; set; }
    public string Nome { get; set; }

    public ReadAddressDTO ReadAdressDTO { get; set; }
}
