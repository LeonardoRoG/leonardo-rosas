using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Novit.Academia.Domain;

[Table("Reserva")]
public class Reserva
{
    [Key]
    public int IdReserva { get; set; }

    [StringLength(50)]
    public required string Cliente { get; set; }

    [ForeignKey("IdProducto")]
    public required Producto Producto { get; set; }

    public EstadoReserva EstadoReserva { get; set; }
}

public enum EstadoReserva
{
    Ingresada,
    Cancelada,
    Aprobada,
    Rechazada
}