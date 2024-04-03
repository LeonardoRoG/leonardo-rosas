using Novit.Academia.Domain;

namespace Novit.Academia.Endpoints.DTO;

public class ReservaDto
{
    public int IdReserva { get; set; }
    public required ClienteDto Cliente { get; set; }
    public required ProductoDto Producto { get; set; }
    public required EstadoReserva EstadoReserva { get; set; }
    public bool SolicitarAprobacion { get; set; }
    public required UsuarioReservaDto Usuario { get; set; }
}

public class ReservaResponseDto
{
    public int IdReserva { get; set; }
    public required ClienteDto Cliente { get; set; }
    public required ProductoResponseDto Producto { get; set; }
    public required EstadoReserva EstadoReserva { get; set; }
    public bool SolicitarAprobacion { get; set; }
    public required UsuarioReservaDto Usuario { get; set; }
}

public class ReservaRequestDto
{
    public required ClienteRequestDto Cliente { get; set; }
    public required EstadoReserva EstadoReserva { get; set; }
    public bool SolicitarAprobacion { get; set; }
    public required UsuarioReservaRequestDto Usuario { get; set; }
}
