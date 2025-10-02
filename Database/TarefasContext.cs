using ApiTarefas.Models;
using ApiTarefas.Services;
using Microsoft.EntityFrameworkCore;
namespace ApiTarefas.Database;

public class TarefasContext : DbContext
{
    #nullable disable
    public TarefasContext(DbContextOptions<TarefasContext> options) : base(options)
    {
        Options = options;
    }

    public DbSet<Tarefa> Tarefas { get; set; }
    public DbContextOptions<TarefasContext> Options { get; }

    public static implicit operator TarefasContext(TarefaService v)
    {
        throw new NotImplementedException();
    }
}