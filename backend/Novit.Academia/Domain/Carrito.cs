using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Novit.Academia.Domain;

[Table("Carrito")]
public class Carrito
{
    [Key]
    public int IdCarrito { get; set; }

    public List<ItemCarrito> Items { get; set; } = [];

    public bool Estado { get; set; } = true;

    public decimal Total() => Items.Sum(item => item.Subtotal());
}
