using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;

namespace ApiTarefas.Models;

[Table(name: "Tarefas")]
public class Tarefa
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; } = default!;

    [Required]
    [StringLength(100)]
    public string Titulo { get; set; } = default!;

    [Column(TypeName = "text")]
    public string Descricao { get; set; } = default!;
    public bool Concluida { get; set; } = default!;

}