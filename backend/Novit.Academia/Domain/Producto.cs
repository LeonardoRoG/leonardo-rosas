using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Novit.Academia.Domain;

[Table("Producto")]
public class Producto
{
    [Key]
    public int IdProducto { get; set; }

    public required string Codigo { get; set; }

    [ForeignKey("IdBarrio")]
    public required Barrio Barrio { get; set; }

    public required decimal Precio { get; set; }

    [StringLength(200)]
    public string? UrlImagen { get; set; }

    public required Estado Estado { get; set; }
}

public enum Estado
{
    Disponible,
    Reservado,
    Vendido
}