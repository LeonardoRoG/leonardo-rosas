using Carter;
using Microsoft.AspNetCore.Mvc;
using Novit.Academia.Database;
using Novit.Academia.Domain;
using Novit.Academia.Endpoints.DTO;
using Novit.Academia.Service;

namespace Novit.Academia.Endpoints;

public class ProductoEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder routes)
    {
        var app = routes.MapGroup("/api/Producto");

        app.MapGet("/", (IProductoService productoService) =>
        {
            var productos = productoService.GetProductos();
            return Results.Ok(productos);

        }).WithTags("Producto");

        app.MapGet("/{idProducto:int}", (IProductoService productoService, int idProducto) =>
        {
            var producto = productoService.GetProducto(idProducto);
            return Results.Ok(producto);

        }).WithTags("Producto");

        app.MapPost("/", ([FromServices] IProductoService productoService, [FromBody] ProductoRequestDto productoDto) =>
        {
            productoService.CreateProducto(productoDto);
            return Results.Created();

        }).WithTags("Producto");

        app.MapPut("/{idProducto}", ([FromServices] IProductoService productoService, int idProducto, [FromBody] ProductoRequestDto productoDto) =>
        {
            productoService.UpdateProducto(idProducto, productoDto);
            return Results.Ok();

        }).WithTags("Producto");

        app.MapDelete("/{idProducto}", (IProductoService productoService,int idProducto) =>
        {
            productoService.RemoveProducto(idProducto);
            return Results.NoContent();

        }).WithTags("Producto");
    }
}
