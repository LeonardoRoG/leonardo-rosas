﻿using Carter;
using Novit.Academia.Database;

namespace Novit.Academia.Endpoints;

public class CarritoEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder routes)
    {
        var app = routes.MapGroup("/api/Carrito");

        app.MapGet("/", (AppDbContext context) =>
        {
            var carritos = context.Carritos.ToList();

            return Results.Ok(carritos);
        }).WithTags("Carrito");

        app.MapGet("/{idCarrito}", (int idCarrito) => 
        {
            return Results.Ok();
        }).WithTags("Carrito");

        app.MapPost("/", () => 
        {
            return Results.Ok();
        }).WithTags("Carrito");

        app.MapDelete("/{idCarrito}", (int idCarrito) => 
        {
            return Results.Ok();
        }).WithTags("Carrito");

        app.MapPost("/{idCarrito}/Producto", (int idCarrito) =>
        {
            return Results.Ok();
        }).WithTags("Carrito");

        app.MapDelete("/{idCarrito}/Producto", (int idCarrito) => 
        {
            return Results.Ok();
        }).WithTags("Carrito");

        app.MapPost("/{idCarrito}/Checkout", (int idCarrito) => 
        {
            return Results.Ok();
        }).WithTags("Carrito");
    }
}
