using Microsoft.AspNetCore.Mvc;
using MovieApi.Models;

namespace MovieApi.Controllers;


// Para que seja um controlador e esteja abil a receber requesiçoes 
// 1 : Anotaçoes :
[ApiController]
//1.1 Anotaçoes de rota 
//rota tem que ser para o nome do controlador ( controller )
[Route("[controller]")]

// 1.3 : temos que extender , ControllerBase
public class MovieController : ControllerBase
{
    [HttpPost]//4:  vamos fazer uma Postagem do filme 
    // 2 : Metodo para registar um filme 
    // Para adicionar o filme no Sistema mas temos que receber alguma informaçao, via parametro
    // iremos receber um filme como parametro
    public void AddMovie(Filme filme)
    {
        // vamos ter que adicionar o filme a uma lista 
        filmes.Add(filme);
        Console.WriteLine(filme.Title);
        Console.WriteLine(filme.Time);
    }

    // 3: Temos que criar : Lista 
    // temos que criar o objecto --> classe que representa , filme no programa
    private static List<Filme> filmes = new List<Filme>();


   
}