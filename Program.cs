using ApiTarefas.Database;
using ApiTarefas.Models;
using ApiTarefas.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<TarefasContext>(Options =>
    Options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 43))));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Add services to the container.

builder.Services.AddScoped<TarefaService>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
