﻿using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Data;
using MovieApi.Data.DTO;
using MovieApi.Models;
using System.Security.Cryptography.X509Certificates;

namespace MovieApi.Controllers;


// Para que seja um controlador e esteja habil a receber requesiçoes 
// 1 : Anotaçoes :
[ApiController]
//1.1 Anotaçoes de rota 
//rota tem que ser para o nome do controlador ( controller )
[Route("[controller]")]

// 1.3 : temos que extender , ControllerBase
public class MovieController : ControllerBase
{
    /// <summary>
    /// Adiciona um filme ao banco de dados
    /// </summary>
    /// <param name="filmeDto">Objeto com os campos necessários para criação de um filme</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>

    [HttpPost]//4:  vamos fazer uma Postagem do filme 
              //5 : Neste momento fizemos um Post no Postman , com url : 7078/Movie 
              //5: passamos no body um Json , com o titulo , genero e time e deu codigo 200, ok
              // --> na consola apareve o codigo 200 e ALURA Movie
              // Neste momento passamos um filme  na nossa lista 

    //Informaçao que podemos passar , para o swagger com o que faz o metodo , que parametros sao actualizados etc
    //temos que ir ao program.cs 
    // temos de ir ao nosso MovieApi(projecto) carregar duas vezes em cima e acrescentar :  <GenerateDocumentationFile>true</GenerateDocumentationFile>
    [ProducesResponseType(StatusCodes.Status201Created)]

    // 2 : Metodo para registar um filme 
    // Para adicionar o filme no Sistema mas temos que receber alguma informaçao, via parametro
    // iremos receber um filme como parametro

    //public void AddMovie([FromBody] Movie filme)



    //public IActionResult AddMovie([FromBody] Movie filme) -- > nao vamos mais enviar um filme mas um CreateMovieDTO
    public IActionResult AddMovie([FromBody] CreateMovieDTO filmeDTO)
    {


        //DTO -- > Quero fazer um filme apartir de um filme DTO --> final !!!
        // GIve all information without GIve all information !!
        Movie filme = _mapper.Map<Movie>(filmeDTO);

        // ESTA SERIA UMA POSSIBILIDADE PARA POR CERTOS LIMITES E VALLIDAÇOES , PARA RESPEITE CERTAS REGRAS
        // Mas existe uma melhor maneira --> data notations !! Por os requesitros em cima dos campos da classe

        //if (
        //    !string.IsNullOrEmpty(filme.Title) && filme.Title.Length <= 300 &&
        //        !string.IsNullOrEmpty(filme.Gender) && filme.Time >= 25
        //        ) ;


        // vamos ter que adicionar o filme a uma lista 

        //ja nao necessario . Uso do context !!
        //filmes.Add(filme);
        _context.Filmes.Add(filme);
        //DEPOIS DE Adicionar --> PRECISAMOS DE Confirmar/salvar 
        _context.SaveChanges();

        //Console.WriteLine(filme.Title);
        //Console.WriteLine(filme.Time);
        // By ID

        //ja nao necessario . Uso do context !!
        //filme.Id = id++;




        //Devemos retornar o objecto , que foi criado 
        // Devo informar para o user , qual o caminho que foi cadastrado o objecto 
        // Quando fazemos um post , no intuito de Post , 

        //Metodo --> buscar o metodo --> paramentros os objectos que vou precisar , id , o id do filme = filme.id ( id do filme que foi criado)
        // por ultimo , o objecto que foi criado , no sistema
        // Agora o que faz no postman , se fizermos Post , e visualizarmos nos Headers podemos ver que sempre que criamos um filme o Url, passa sempre um novo id , para cada filme 
        // o que acontece é da-me umn status code 201 , que algo foi criado 
        return CreatedAtAction(nameof(RecoverMovieById), new { id = filme.Id }, filme);
    }


    // 3: Temos que criar : Lista 
    // temos que criar o objecto --> classe que representa , filme no programa
    //private static List<Movie> filmes = new List<Movie>();

    //Metodo de leitura

    [HttpGet]
    //Nao preciso de parametros a passar no metodo
    //public IEnumerable<Movie> ReadListFIlms([FromQuery] int skip = 0, [FromQuery] int take = 20)
   
    public IEnumerable<ReadMovieDTO> ReadListFIlms([FromQuery] int skip = 0, [FromQuery] int take = 20)
    // Vamos trocar a List por IEnumerable ( vamos mudar o retorno da lista de filmes , para retorno de Enumeravel de filemes )
    // Se no futuro houver mudança da lista para outro tipo de classe que use a mesma interface , nao precisamos de trocar o cabeçalho do nosso metodo
    // Quanto menos depndermos de classes concretas, mas sim de interfaces melhor !!
    //public List<Movie> ReadListFIlms()
    {
        //ja nao necessario . Uso do context !!
        //return filmes.Skip(skip).Take(take);
        return  _mapper.Map<List<ReadMovieDTO>>(_context.Filmes.Skip(skip).Take(take));
        //vamos querer mapear o filme para uma lista readmovieDTO , o nosso context.movie
    }


    // recover movie By Id 

    //private static int id = 0;


    // O que muda ? --> Agora com id , no URL nos podemos fazer o post que nos da o filme com id . Podemos fazer o metodo Get para recuperar
    // todos os filmes . =>=> O que muda é neste momento no URL podemos so passar o id do filme , o que nos da so o filme que tem esse ID
    // fazemos a recuperaçao de forma unica !!
    [HttpGet("{id}")]//tenho de passar o parametro ID . Quando eu passar o id ele passa este Get , se eu  nao passar ele executa o de cima


    public IActionResult RecoverMovieById(int id)//Mudamos de Movie? => IActionResult(Dava erro o return porque nao é mais um filme)
                                                 //é o reusltado de uma açao que foi executada
    /* public Movie? RecoverMovieById(int id)*/// filme pode ser ou nao nulo 

    {

        // da minha lista de filmes quero recuperar o meu 1 elemento 
        // onde o filme que eu estou a buscar tenha id = ao id conhecido por parametro 

        // vamos fazrer a alteraçao do return para ==> var filme ( "o filme que  for recuperado apartir da nossaconsulta , for nulo = notfound")
        //return  filmes.FirstOrDefault(filme => filme.Id == id); ---> vamos mudar aqui e da erro no return --> temos que mudar o public Movie

        //ja nao necessario . Uso do context !!
        //var filme = filmes.FirstOrDefault(filme => filme.Id == id);
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null)
        {
            return NotFound($"Movie nao foi encontrado");
        }
        else
        {
            var filmeDto = _mapper.Map<ReadMovieDTO>(filme);
            return Ok(filmeDto);
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

    //public IEnumerable<Movie> ReadListFIlms([FromQuery] int skip = 0, [FromQuery] int take = 20)

    //{
    //    return filmes.Skip(skip).Take(take);
    //}
    //-------------------------------//
    //---------------------------------------------//
    //----------------------------------------------------//








    //----------------------------------------------------//
    //---------------------------------------------//
    //-------------------------------//

    //Intalamos Framework entity ==>  Entity.FrameworkCore && Entity.FrameworkTools ----> Mais Importantes 
    // vamos precisar disto para guardar dadod ( ter conecçao com banco de dados )


    //Temos que fazer a conecçao com banco de dados => Classe Criada FilmeContext

    //-------------------------------//
    //---------------------------------------------//
    //----------------------------------------------------//










    //----------------------------------------------------//
    //---------------------------------------------//
    //-------------------------------//

    // Para fazermos a utilçizaçao e conecçao do nosso banco de dados vamos fazer a remoçao dos "private" das Listas : 
    //private static int id = 0;
    //private static List<Movie> filmes = new List<Movie>();

    //Aqui vamos querer : :  -->  que o controlador utilize o Context (resoponsavel de acessar ao banco de dados - entre nossa app e banco de dados )
    // o nosso controlador de filme , depende da funcionalidade e da injecçao do context . Como fazemos ?? :: 

    // Apartir daqui o filmes.Id e o filmes.Add ja nao sao precisos !! 
    private FilmeContext _context;
    private IMapper _mapper;
    public MovieController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    //-------------------------------//
    //---------------------------------------------//
    //----------------------------------------------------//




    // Metodo para actualizaçao de um filme --> temos ja o valor dos campos do banco 
    [HttpPut("{id}")] // para actualizar eu tenho que passar o objecto inteiro --> util isar o patch para actualizar o campo 
    public IActionResult MovieUpdate(int id, [FromBody] UpdateMovieDTO filmeDTO)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null) return NotFound();


        _mapper.Map(filmeDTO, filme);
        _context.SaveChanges();

        //retornar um status code 
        return NoContent();

    }



    // Tive que instalar o NewtonSoft --> depois build no program.cs
    [HttpPatch("{id}")]
    //JsonPatchDocument vai ser referente ao UpdateFilmeDto -->  vai conter 1 ou mais informaçoes respectivas a um filme ( chamamos de patch ) 
    // vamos converter o filme do banco para um UpdateFilmeDto


    //json parcial , do que queremos mudar --> ele recebe 1 ou mais informaçoes resctivas ao MovieDTO
    // agora nao recebemos o movieDTO mas recebemos um JSonpatchDocument
    public IActionResult MovieFiledOnlyUpdate(int id, JsonPatchDocument<UpdateMovieDTO> patch)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);   // receber e ver o filme que nos temos
        if (filme == null) return NotFound(); // caso nao encontre --> not found()

        //o que precisamos é de converter um filme do banco para updatemovieDTO , para aplicar as regras de validaçao . Se o DTO estiver valido convertemos novamente para um filme 
        var filmeToUpdate = _mapper.Map<UpdateMovieDTO>(filme);
        // Se a mudança que estamos a tentar aplicar , patch , for aplicada ao nosso filmeToUpdate e contiver um modelo de estao (ModelState) , 
        // converte de volta para um filme , se nao retorna , da erro de validaçao
        patch.ApplyTo(filmeToUpdate, ModelState);
        if (!TryValidateModel(filmeToUpdate))// Se nao conseguir validar o modelo --> retorna validation Problem apartir do modelstate 
        {
            return ValidationProblem(ModelState);
        }
        // ser for tudo ok , retorna o filme para actualizar para um filme 
        // vamos precisar de CreateMap<> !!!
        _mapper.Map(filmeToUpdate, filme);
        _context.SaveChanges();
        return NoContent();

        //campos que temos que por para conseguirmos mudar o campo
        //        [{
        //            "op": "replace",
        //            "path": "/Title",
        //            "value": "senhor dos aneis"
        //       }]
    }



    [HttpDelete("{id}")]
    public IActionResult DeleteById(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null) return NotFound();
        _context.Remove(filme);
        _context.SaveChanges();
        return NoContent();
    }




    // Nos temos o recupera filmes por ID e o recupera filmes , metodo !!
    // vamos criar uma nova classe , ReadFilmesDto

}