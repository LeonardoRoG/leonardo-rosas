using Novit.Academia.Domain;

namespace Novit.Academia.Endpoints.DTO;

public record ProductoDto
(
    string Codigo,
    string Barrio,
    decimal Precio,
    string? UrlImagen
);

public record ProductoReservaDto(
    Estado Estado
    );