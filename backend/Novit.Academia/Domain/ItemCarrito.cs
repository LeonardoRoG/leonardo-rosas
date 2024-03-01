using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Novit.Academia.Domain;

[Table("ItemCarrito")]
public class ItemCarrito
{
    [Key]
    public int IdItemCarrito { get; set; }
    
    public int Cantidad { get; set; } = 1;

    [ForeignKey("IdProducto")]
    public required Producto Producto { get; set; }

    [ForeignKey("IdCarrito")]
    public required Carrito Carrito { get; set; }

    public decimal Subtotal() => Producto.Precio * Cantidad;
}
