using Carter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        })
            .WithTags("Reserva")
            .RequireAuthorization(new AuthorizeAttribute { Roles = "vendedor, comercial" });

        app.MapGet("/{idReserva:int}", (IReservaService reservaService, int idReserva) =>
        {
            var reserva = reservaService.GetReserva(idReserva);
            return Results.Ok(reserva);

        })
            .WithTags("Reserva")
            .RequireAuthorization(new AuthorizeAttribute { Roles = "vendedor, comercial" });

        app.MapPost("/{idProducto:int}", (IReservaService reservaService, int idProducto, [FromBody] ReservaRequestDto reservaDto) =>
        {
            var producto = reservaService.AddReserva(idProducto, reservaDto);
            return Results.Ok();

        })
            .WithTags("Reserva")
            .RequireAuthorization(new AuthorizeAttribute { Roles = "vendedor" });

        app.MapPut("/{idReserva:int}/Cancelar", (IReservaService reservaService, int idReserva) =>
        {
            reservaService.CancelReserva(idReserva);
            return Results.Ok();

        })
            .WithTags("Reserva")
            .RequireAuthorization(new AuthorizeAttribute { Roles = "vendedor" });

        app.MapPut("/{idReserva:int}/Rechazar", (IReservaService reservaService, int idReserva) =>
        {
            reservaService.RejectReserva(idReserva);
            return Results.Ok();

        })
            .WithTags("Reserva")
            .RequireAuthorization(new AuthorizeAttribute { Roles = "comercial" });

        app.MapPut("/{idReserva:int}/Aprobar", (IReservaService reservaService, int idReserva) =>
        {
            reservaService.ApproveReserva(idReserva);
            return Results.Ok();

        })
            .WithTags("Reserva")
            .RequireAuthorization(new AuthorizeAttribute { Roles = "comercial" });

        app.MapPut("/{idReserva:int}/Update", (IReservaService reservaService, int idReserva, [FromBody] ReservaRequestDto reservaDto) =>
        {
            reservaService.UpdateReserva(idReserva, reservaDto);
            return Results.Ok();

        })
            .WithTags("Reserva")
            .RequireAuthorization(new AuthorizeAttribute { Roles = "comercial" });

    }
}
