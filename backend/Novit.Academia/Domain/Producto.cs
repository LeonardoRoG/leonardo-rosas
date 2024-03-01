using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Novit.Academia.Domain;

[Table("Producto")]
public class Producto
{
    [Key]
    public int IdProducto { get; set; }

    [StringLength(30)]
    public required string Nombre { get; set; }

    [StringLength(50)]
    public string? Descripcion { get; set; }

    public required decimal Precio { get; set; }

    [StringLength(200)]
    public string? UrlImagen { get; set; }

    public int Stock { get; set; } = 0;

    public List<ItemCarrito> Items { get; set; } = [];
}
