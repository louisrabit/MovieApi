using Microsoft.EntityFrameworkCore;
using MongoDB.Driver.Core.Configuration;
using MovieApi.Data;

var builder = WebApplication.CreateBuilder(args);

//Nuget : entity.framework.core.Mysql
builder.Services.AddDbContext<FilmeContext>(opts =>
opts.UseMySql(ConnectionString, ServerVersion.AutoDetect(connectionString) )
);

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
