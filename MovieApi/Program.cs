using Microsoft.EntityFrameworkCore;
using MovieApi.Data;

var builder = WebApplication.CreateBuilder(args);


// QUESTAO DE AUtenticaçao !!
var connectionString = builder.Configuration.GetConnectionString("FilmeConnection");
//Nuget : entity.framework.core.Mysql
builder.Services.AddDbContext<FilmeContext>(opts =>
//versao que ele esta + Autodetect a versao 
opts.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
