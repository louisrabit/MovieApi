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
    //5 : Neste momento fizemos um Post no Postman , com url : 7078/Movie 
    //5: passamos no body um Json , com o titulo , genero e time e deu codigo 200, ok
    // --> na consola apareve o codigo 200 e ALURA Movie
    // Neste momento passamos um filme  na nossa lista 

    // 2 : Metodo para registar um filme 
    // Para adicionar o filme no Sistema mas temos que receber alguma informaçao, via parametro
    // iremos receber um filme como parametro
    public void AddMovie([FromBody] Filme filme)
    {

        // ESTA SERIA UMA POSSIBILIDADE PARA POR CERTOS LIMITES E VALLIDAÇOES , PARA RESPEITE CERTAS REGRAS
        // Mas existe uma melhor maneira --> data notations !! Por os requesitros em cima dos campos da classe

        //if (
        //    !string.IsNullOrEmpty(filme.Title) && filme.Title.Length <= 300 &&
        //        !string.IsNullOrEmpty(filme.Gender) && filme.Time >= 25
        //        ) ;


        // vamos ter que adicionar o filme a uma lista 
        filmes.Add(filme);
        Console.WriteLine(filme.Title);
        Console.WriteLine(filme.Time);
    }


    // 3: Temos que criar : Lista 
    // temos que criar o objecto --> classe que representa , filme no programa
    private static List<Filme> filmes = new List<Filme>();

    //Metodo de leitura

    [HttpGet]
    public List<Filme> ReadListFIlms()
    {
        return filmes;
    }

}