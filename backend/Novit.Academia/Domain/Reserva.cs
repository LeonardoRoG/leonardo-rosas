using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Novit.Academia.Domain;

[Table("Reserva")]
public class Reserva
{
    [Key]
    public int IdReserva { get; set; }

    [ForeignKey("IdCliente")]
    public required Cliente Cliente { get; set; }

    [ForeignKey("IdProducto")]
    public required Producto Producto { get; set; }

    public required EstadoReserva EstadoReserva { get; set; }

    public bool SolicitarAprobacion { get; set; }

    public required Usuario Usuario { get; set; }
}

public enum EstadoReserva
{
    Ingresada,
    Cancelada,
    Aprobada,
    Rechazada
}