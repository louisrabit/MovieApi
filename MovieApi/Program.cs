using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MovieApi.Data;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


// QUESTAO DE AUtenticaçao !!
var connectionString = builder.Configuration.GetConnectionString("FilmeConnection");
//Nuget : entity.framework.core.Mysql
builder.Services.AddDbContext<FilmeContext>(opts =>
//versao que ele esta + Autodetect a versao 
opts.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers().AddNewtonsoftJson();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


//Nome para swaggewr alterado !! 
// temos de ir ao nosso MovieApi(projecto) carregar duas vezes em cima e acrescentar :  <GenerateDocumentationFile>true</GenerateDocumentationFile>
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "FilmesAPI", Version = "v1" });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
