using System.ComponentModel.DataAnnotations;

namespace MovieApi.Models;

public class Filme
{
    public Filme(string title, int time, string gender)
    {
        Title = title;
        Time = time;
        Gender = gender;
    }


    // Data notations => Required + Error Message +  etc..
    [Required(ErrorMessage = "The Title field is required.")]
    [MaxLength(50, ErrorMessage = "Max Leght , 50 characters")]
    public string Title { get; set; }
    [Required(ErrorMessage = "The Time field is required. ")]
    [Range(1, 400, ErrorMessage = "Movie need to have more than 1 minute and equal or less than 400 minuts")]
    public int Time { get; set; }
    [Required(ErrorMessage = "The Gender field is required.")]
    public string Gender { get; set; }

}
