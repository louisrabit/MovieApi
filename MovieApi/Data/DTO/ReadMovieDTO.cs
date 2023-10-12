using System.ComponentModel.DataAnnotations;

namespace MovieApi.Data.DTO;



public class ReadMovieDTO
{
    public string Title { get; set; }
    public int Time { get; set; }
    public string Gender { get; set; }

    // > Informaçao que podemos criar que nao pertence ao filme , mas pertence ao scope do DTO unicamente
    public DateTime DateWatchMovie { get; set; } = DateTime.Now;




}
