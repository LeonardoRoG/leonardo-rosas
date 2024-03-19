namespace Novit.Academia.Endpoints.DTO;

public class BarrioDto
{
    public int IdBarrio { get; set; }
    public required string Nombre { get; set; }
}

public class BarrioResponseDto
{
    public int IdBarrio { get; set; }
    public required string Nombre { get; set; }
}

public class BarrioRequestDto
{
    public required string Nombre { get; set; }
}
