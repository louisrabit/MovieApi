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
        // By ID
        filme.Id = id++;
    }


    // 3: Temos que criar : Lista 
    // temos que criar o objecto --> classe que representa , filme no programa
    private static List<Filme> filmes = new List<Filme>();

    //Metodo de leitura

    [HttpGet]
    //Nao preciso de parametros a passar no metodo
    public IEnumerable<Filme> ReadListFIlms()
    // Vamos trocar a List por IEnumerable ( vamos mudar o retorno da lista de filmes , para retorno de Enumeravel de filemes )
    // Se no futuro houver mudança da lista para outro tipo de classe que use a mesma interface , nao precisamos de trocar o cabeçalho do nosso metodo
    // Quanto menos depndermos de classes concretas, mas sim de interfaces melhor !!
    //public List<Filme> ReadListFIlms()
    {
        return filmes;
    }


    // recover movie By Id 

    private static int id = 0;


    // O que muda ? --> Agora com id , no URL nos podemos fazer o post que nos da o filme com id . Podemos fazer o metodo Get para recuperar
    // todos os filmes . =>=> O que muda é neste momento no URL podemos so passar o id do filme , o que nos da so o filme que tem esse ID
   // fazemos a recuperaçao de forma unica !!
    [HttpGet("{id}")]//tenho de passar o parametro ID . Quando eu passar o id ele passa este Get , se eu  nao passar ele executa o de cima

    public Filme? RecoverMovieById(int id)// filme pode ser ou nao nulo 

    {
        
        // da minha lista de filmes quero recuperar o meu 1 elemento 
        // onde o filme que eu estou a buscar tenha id = ao id conhecido por parametro 
      return  filmes.FirstOrDefault(filme => filme.Id == id);
    }
}