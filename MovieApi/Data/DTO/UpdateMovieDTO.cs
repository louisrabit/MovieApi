using System.ComponentModel.DataAnnotations;

namespace MovieApi.Data.DTO;

public class UpdateMovieDTO
{
    // Nao precisamos que o usuario envie o ID por isso apagamos !!
    // vamos agora nao enviar um filme mas um CreateMovieDTO


    [Required(ErrorMessage = "The Title field is required.")]


    //é diferente do MaxLenght porque nao faz a alocaçao de memoria dentro do banco de dados (stringlenght)
    [StringLength(50, ErrorMessage = "Max Leght , 50 characters")]
    public string Title { get; set; }

    [Required(ErrorMessage = "The Time field is required. ")]
    [Range(1, 400, ErrorMessage = "Movie need to have more than 1 minute and equal or less than 400 minuts")]
    public int Time { get; set; }


    [Required(ErrorMessage = "The Gender field is required.")]
    public string Gender { get; set; }


}
