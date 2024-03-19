using Novit.Academia.Domain;

namespace Novit.Academia.Endpoints.DTO;

//public record ProductoDto
//(
//    string Codigo,
//    Barrio Barrio,
//    decimal Precio,
//    string? UrlImagen
//);

//public record ProductoReservaDto(
//    Estado Estado
//    );

public class ProductoDto
{
    public int IdProducto { get; set; }
    public required string Codigo { get; set; }
    public required BarrioDto Barrio { get; set; }
    public decimal Precio { get; set; }
    public string? UrlImagen { get; set; }
    public required Estado Estado { get; set; }
}

public class ProductoResponseDto
{
    public int IdProducto { get; set; }
    public required string Codigo { get; set; }
    public required BarrioResponseDto Barrio { get; set; }
    public decimal Precio { get; set; }
    public string? UrlImagen { get; set; }
    public required Estado Estado { get; set; }
}

public class ProductoRequestDto
{
    public required string Codigo { get; set; }
    public required BarrioRequestDto Barrio { get; set; }
    public decimal Precio { get; set; }
    public string? UrlImagen { get; set; }
    public required Estado Estado { get; set; }
}

public class ProductoReservaDto
{
    public required Estado Estado { get; set; }
}