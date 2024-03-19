using Carter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Novit.Academia.Database;
using Novit.Academia.Domain;
using Novit.Academia.Endpoints.DTO;
using Novit.Academia.Service;

namespace Novit.Academia.Endpoints;

public class ReservaEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder routes)
    {
        var app = routes.MapGroup("/api/Reserva");

        app.MapGet("/", (IReservaService reservaService) =>
        {
            var reservas = reservaService.GetReservas();
            return Results.Ok(reservas);

        }).WithTags("Reserva");
        
        app.MapGet("/{idReserva:int}", (IReservaService reservaService, int idReserva) =>
        {
            var reserva = reservaService.GetReserva(idReserva);
            return Results.Ok(reserva);

        }).WithTags("Reserva");
        
        app.MapPost("/{idProducto:int}", (IReservaService reservaService, int idProducto , [FromBody] ReservaRequestDto reservaDto) =>
        {
            var producto = reservaService.AddReserva(idProducto, reservaDto);
            return Results.Ok();

        }).WithTags("Reserva");
        
        app.MapDelete("/{idReserva:int}", (IReservaService reservaService, int idReserva) =>
        {
            reservaService.RemoveReserva(idReserva);
            return Results.NoContent();

        }).WithTags("Reserva");
        
        app.MapPut("/{idReserva:int}", (IReservaService reservaService, int idReserva, [FromBody] ReservaRequestDto reservaDto) =>
        {
            reservaService.UpdateReserva(idReserva, reservaDto);
            return Results.Ok();

        }).WithTags("Reserva");

    }
}
