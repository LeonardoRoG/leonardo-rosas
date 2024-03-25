using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Novit.Academia.Domain;

[Table("Rol")]
public class Rol
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public List<Usuario> Usuarios { get; set; } = [];
}
