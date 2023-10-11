using Microsoft.EntityFrameworkCore;
using MovieApi.Models;
using System.Security.Cryptography;

namespace MovieApi.Data;


// Temos de ter um contexto para fazer uma conecçao , ligaçao entre App e banco de dados 
// classe contexto para o nosso contexto de Filmes 

// Vai ter que extender DbContext 
public class FilmeContext : DbContext //Abstrair a lógica de acesso ao banco de dados.Dessa maneira, nosso esforço de acessar o banco de dados é reduzido.
{
    //contrutor  [ ctr + tab + tab  ]
    // O que este contrutior vai receber vai ser as opçoes de acesso ao Banco
    // Vai receber o FilmeContext e chamamos de opts
    // Nao vamos fazer a utilizaçao dele , dentro deste construtor --> vamos fazer a passagem da opcoes para o contrutor da classe que estamos a estender , Dbcontext

    public FilmeContext(DbContextOptions<FilmeContext> opts) : base(opts)
    {

    }

    //Propriedade de acesso --> Acesso aos filmes na nossa base
    public DbSet<Filme> Filmes { get; set; }

    // Como app se autentica no banco ? tem acesso ao banco ? --> appsettings
    // Como passamos os valores para o banco de dados como uma tabela ?? --> Filmeclass[key]


}