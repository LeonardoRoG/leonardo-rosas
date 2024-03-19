using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Novit.Academia.Domain;

[Table("Cliente")]
public class Cliente
{
    [Key]
    public int IdCliente { get; set; }

    [StringLength(50)]
    public required string Nombre { get; set; }
}
