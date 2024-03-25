using Carter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        })
            .WithTags("Producto")
            .RequireAuthorization(new AuthorizeAttribute { Roles = "vendedor" });

        app.MapGet("/{idProducto:int}", (IProductoService productoService, int idProducto) =>
        {
            var producto = productoService.GetProducto(idProducto);
            return Results.Ok(producto);

        })
            .WithTags("Producto")
            .RequireAuthorization(new AuthorizeAttribute { Roles = "vendedor" });

        app.MapPost("/", ([FromServices] IProductoService productoService, [FromBody] ProductoRequestDto productoDto) =>
        {
            productoService.CreateProducto(productoDto);
            return Results.Created();

        })
            .WithTags("Producto")
            .RequireAuthorization(new AuthorizeAttribute { Roles = "vendedor" });

        app.MapPut("/{idProducto}", ([FromServices] IProductoService productoService, int idProducto, [FromBody] ProductoRequestDto productoDto) =>
        {
            productoService.UpdateProducto(idProducto, productoDto);
            return Results.Ok();

        })
            .WithTags("Producto")
            .RequireAuthorization(new AuthorizeAttribute { Roles = "vendedor" });

        app.MapDelete("/{idProducto}", (IProductoService productoService, int idProducto) =>
        {
            productoService.RemoveProducto(idProducto);
            return Results.NoContent();

        })
            .WithTags("Producto")
            .RequireAuthorization(new AuthorizeAttribute { Roles = "vendedor" });
    }
}
