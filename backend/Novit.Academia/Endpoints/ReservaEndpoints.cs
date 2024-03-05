using Carter;
using Microsoft.AspNetCore.Mvc;
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

            if (reservaDto.EstadoReserva == EstadoReserva.Ingresada)
                producto.Estado = Estado.Reservado;
            if (reservaDto.EstadoReserva == EstadoReserva.Cancelada | reservaDto.EstadoReserva == EstadoReserva.Rechazada)
                producto.Estado = Estado.Disponible;
            if (reservaDto.EstadoReserva == EstadoReserva.Aprobada)
                producto.Estado = Estado.Vendido;

            Reserva reserva = new()
            {
                Cliente = reservaDto.Cliente,
                Producto = producto,
                EstadoReserva = reservaDto.EstadoReserva
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
        
        app.MapPut("/{idReserva:int}", (AppDbContext context, int idReserva, [FromBody] ReservaDto reservaDto) =>
        {
            var reserva = context.Reservas.Where(r => r.IdReserva == idReserva)
                .Include(p => p.Producto)
                .FirstOrDefault();

            if (reserva == null)
                return Results.BadRequest($"IdReserva {idReserva} no existe.");

            reserva.EstadoReserva = reservaDto.EstadoReserva;
            reserva.Cliente = reservaDto.Cliente;

            if (reservaDto.EstadoReserva == EstadoReserva.Ingresada)
                reserva.Producto.Estado = Estado.Reservado;
            if (reservaDto.EstadoReserva == EstadoReserva.Cancelada | reservaDto.EstadoReserva == EstadoReserva.Rechazada)
                reserva.Producto.Estado = Estado.Disponible;
            if (reservaDto.EstadoReserva == EstadoReserva.Aprobada)
                reserva.Producto.Estado = Estado.Vendido;
            
            context.SaveChanges();

            return Results.Ok();
        }).WithTags("Reserva");

    }
}
