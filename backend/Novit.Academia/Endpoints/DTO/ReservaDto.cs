using Novit.Academia.Domain;

namespace Novit.Academia.Endpoints.DTO;

public class ReservaDto
{
    public required string Cliente { get; set; }
    public EstadoReserva EstadoReserva { get; set; }
}
