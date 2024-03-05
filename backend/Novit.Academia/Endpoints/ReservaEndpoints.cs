using Carter;
using Microsoft.EntityFrameworkCore;
using Novit.Academia.Database;
using Novit.Academia.Domain;
using Novit.Academia.Endpoints.DTO;

namespace Novit.Academia.Endpoints;

public class ReservaEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder routes)
    {
        var app = routes.MapGroup("/api/Reserva");

        app.MapGet("/", (AppDbContext context) =>
        {
            var reservas = context.Reservas
                .Include(x => x.Producto)
                .ToList();

            return Results.Ok(reservas);
        }).WithTags("Reserva");
        
        app.MapGet("/{idReserva:int}", (AppDbContext context, int idReserva) =>
        {
            var reserva = context.Reservas
                .Where(r => r.IdReserva == idReserva)
                .Include(x => x.Producto)
                .FirstOrDefault();

            if (reserva == null)
                return Results.BadRequest($"IdReserva {idReserva} no existe.");

            return Results.Ok(reserva);
        }).WithTags("Reserva");
        
        app.MapPost("/{idProducto:int}", (AppDbContext context, int idProducto ,ReservaDto reservaDto) =>
        {
            var producto = context.Productos.FirstOrDefault(p => p.IdProducto == idProducto);
            if (producto == null)
                return Results.BadRequest($"IdProducto {idProducto} no existe.");
            producto.Estado = reservaDto.Producto.Estado;
            Reserva reserva = new()
            {
                Cliente = reservaDto.Cliente,
                Producto = producto,
                EstadoReserva = EstadoReserva.Ingresada
            };
            
            context.Reservas.Add( reserva );
            context.SaveChanges();

            return Results.Ok();
        }).WithTags("Reserva");
        
        app.MapDelete("/{idReserva:int}", (AppDbContext context, int idReserva) =>
        {
            var reserva = context.Reservas.FirstOrDefault(r => r.IdReserva == idReserva);

            if (reserva == null)
                return Results.BadRequest($"IdReserva {idReserva} no existe.");

            context.Reservas.Remove( reserva );
            context.SaveChanges();

            return Results.Ok();
        }).WithTags("Reserva");
        
        app.MapPut("/{idReserva:int}", (AppDbContext context, int idReserva, ReservaDto reservaDto) =>
        {
            var reserva = context.Reservas.FirstOrDefault(r => r.IdReserva == idReserva);
            if (reserva == null)
                return Results.BadRequest($"IdReserva {idReserva} no existe.");

            reserva.Cliente = reservaDto.Cliente;
            reserva.EstadoReserva = reservaDto.EstadoReserva;
            // TODO: ifs de los casos de estadoReserva para modificar estado del producto

            return Results.Ok();
        }).WithTags("Reserva");

    }
}
