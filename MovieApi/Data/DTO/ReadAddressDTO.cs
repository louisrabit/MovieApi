using System.ComponentModel.DataAnnotations;

namespace MovieApi.Data.DTO;

public class ReadAddressDTO
{
   
    public int Id { get; set; }
    public string Logradouro { get; set; }
    public int Number { get; set; }
}
