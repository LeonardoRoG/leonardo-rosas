namespace Novit.Academia.Endpoints.DTO;

public class ClienteDto
{
    public int IdCliente { get; set; }
    public required string Nombre { get; set; }
}

public class ClienteRequestDto
{
    public required string Nombre { get; set; }
}

public class ClienteResponseDto
{
    public int IdCliente { get; set; }
    public required string Nombre { get; set; }
}
