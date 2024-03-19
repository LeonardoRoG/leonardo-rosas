using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Novit.Academia.Domain;

[Table("Barrio")]
public class Barrio
{
    [Key]
    public int IdBarrio { get; set; }

    [StringLength(50)]
    public required string Nombre { get; set;}

    [InverseProperty("Barrio")]
    public List<Producto> Productos { get; set; } = [];
}
