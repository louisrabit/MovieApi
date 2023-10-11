using System.ComponentModel.DataAnnotations;
using System.Runtime.Intrinsics.X86;

namespace MovieApi.Models;

public class Filme
{
    public Filme(string title, int time, string gender, int id)
    {
        Title = title;
        Time = time;
        Gender = gender;
        Id = id;
    }


    // Como passamos os campos para o banco de dados como uma tabela ??

    //Comando --> Gerenciador de pacotes de Nuget --> Add-Migration + " " + "nome" ( migra os dados da app para o banco de dados )
    //actualizamos a base de dados == > Update-Database
    // Faz o Build do nosso Codigo --> faz uma Pasta Migrations !! 


    // {[
    //mySql -- > commands show databases;
    //show databases; --> mostra a basededados "filme"
    //use filme; 
    //show tables; --> mostra a "tabela"
    //describe filmes; --> mostra os campos da tabela7
    // select * from filmes --> mostra todos os filmes quje estao na base de dados 
    // ]}


    [Key] //o ID é una chave dentro do banco de dados --> especificar 
    [Required]
    public int Id { get; set; }
    // Data notations == > Required + Error Message +  etc..
    [Required(ErrorMessage = "The Title field is required.")]
    [MaxLength(50, ErrorMessage = "Max Leght , 50 characters")]
    public string Title { get; set; }
    [Required(ErrorMessage = "The Time field is required. ")]
    [Range(1, 400, ErrorMessage = "Movie need to have more than 1 minute and equal or less than 400 minuts")]
    public int Time { get; set; }
    [Required(ErrorMessage = "The Gender field is required.")]
    public string Gender { get; set; }

}
