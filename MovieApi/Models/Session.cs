using System.ComponentModel.DataAnnotations;

namespace MovieApi.Models;

public class Session
{
    [Key]
    [Required]
    public int Id { get; set; }
}
