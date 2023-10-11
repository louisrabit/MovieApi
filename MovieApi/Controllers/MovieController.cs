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

    //public void AddMovie([FromBody] Filme filme)
        public IActionResult AddMovie([FromBody] Filme filme)
    {

        // ESTA SERIA UMA POSSIBILIDADE PARA POR CERTOS LIMITES E VALLIDAÇOES , PARA RESPEITE CERTAS REGRAS
        // Mas existe uma melhor maneira --> data notations !! Por os requesitros em cima dos campos da classe

        //if (
        //    !string.IsNullOrEmpty(filme.Title) && filme.Title.Length <= 300 &&
        //        !string.IsNullOrEmpty(filme.Gender) && filme.Time >= 25
        //        ) ;


        // vamos ter que adicionar o filme a uma lista 
        filmes.Add(filme);
        //Console.WriteLine(filme.Title);
        //Console.WriteLine(filme.Time);
        // By ID
        filme.Id = id++;




        //Devemos retornar o objecto , que foi criado 
        // Devo informar para o user , qual o caminho que foi cadastrado o objecto 
        // Quando fazemos um post , no intuito de Post , 

        //Metodo --> buscar o metodo --> paramentros os objectos que vou precisar , id , o id do filme = filme.id ( id do filme que foi criado)
        // por ultimo , o objecto que foi criado , no sistema
        // Agora o que faz no postman , se fizermos Post , e visualizarmos nos Headers podemos ver que sempre que criamos um filme o Url, passa sempre um novo id , para cada filme 
        // o que acontece é da-me umn status code 201 , que algo foi criado 
        return  CreatedAtAction(nameof(RecoverMovieById), new {id = filme.Id}, filme);
    }


    // 3: Temos que criar : Lista 
    // temos que criar o objecto --> classe que representa , filme no programa
    private static List<Filme> filmes = new List<Filme>();

    //Metodo de leitura

    [HttpGet]
    //Nao preciso de parametros a passar no metodo
    public IEnumerable<Filme> ReadListFIlms([FromQuery] int skip = 0, [FromQuery] int take = 20)
    // Vamos trocar a List por IEnumerable ( vamos mudar o retorno da lista de filmes , para retorno de Enumeravel de filemes )
    // Se no futuro houver mudança da lista para outro tipo de classe que use a mesma interface , nao precisamos de trocar o cabeçalho do nosso metodo
    // Quanto menos depndermos de classes concretas, mas sim de interfaces melhor !!
    //public List<Filme> ReadListFIlms()
    {
        return filmes.Skip(skip).Take(take);
    }


    // recover movie By Id 

    private static int id = 0;


    // O que muda ? --> Agora com id , no URL nos podemos fazer o post que nos da o filme com id . Podemos fazer o metodo Get para recuperar
    // todos os filmes . =>=> O que muda é neste momento no URL podemos so passar o id do filme , o que nos da so o filme que tem esse ID
    // fazemos a recuperaçao de forma unica !!
    [HttpGet("{id}")]//tenho de passar o parametro ID . Quando eu passar o id ele passa este Get , se eu  nao passar ele executa o de cima


    public IActionResult RecoverMovieById(int id)//Mudamos de Filme? => IActionResult(Dava erro o return porque nao é mais um filme)
        //é o reusltado de uma açao que foi executada
   /* public Filme? RecoverMovieById(int id)*/// filme pode ser ou nao nulo 

    {

        // da minha lista de filmes quero recuperar o meu 1 elemento 
        // onde o filme que eu estou a buscar tenha id = ao id conhecido por parametro 

        // vamos fazrer a alteraçao do return para ==> var filme ( "o filme que  for recuperado apartir da nossaconsulta , for nulo = notfound")
        //return  filmes.FirstOrDefault(filme => filme.Id == id); ---> vamos mudar aqui e da erro no return --> temos que mudar o public Filme
        var filme = filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null)
        {
            return NotFound($"Filme nao foi encontrado{filme}");
        }
        else
        {
            return Ok(filme);
        }
    }


    //----------------------------------------------------//
    //---------------------------------------------//
    //-------------------------------//
    // NOVA QUESTAO : E SE HOUVE MILHARES DE FILMES ??

    // Podemos ter um problema de memorylieak , problemas no correr da app 
    // --> vamos Poder utilizar PAGINAÇAO <-- vsmos usar os metodos skip  & take 
    // vamos usar estes metodos para haver um carregamento em memoria menor, da quatidade de filmes
    // Skip => passa pelos elemenots ate ao segujinte indicado ( skip = 10 => quando fazemos o GET começamos no id=11)
    // take => ele vai dar 50 elementos 

    //public IEnumerable<Filme> ReadListFIlms([FromQuery] int skip = 0, [FromQuery] int take = 20)

    //{
    //    return filmes.Skip(skip).Take(take);
    //}
    //-------------------------------//
    //---------------------------------------------//
    //----------------------------------------------------//
}