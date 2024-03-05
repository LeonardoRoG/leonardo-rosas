using Carter;
using Novit.Academia.Database;
using Novit.Academia.Domain;
using Novit.Academia.Endpoints.DTO;

namespace Novit.Academia.Endpoints;

public class ProductoEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder routes)
    {
        var app = routes.MapGroup("/api/Producto");

        app.MapGet("/", (AppDbContext context) =>
        {
            var productos = context.Productos.Select(p => p.ConvertToProductoDto());
            return Results.Ok(productos);
        }).WithTags("Producto");

        app.MapGet("/{idProducto:int}", (AppDbContext context ,int idProducto) =>
        {
            var producto = context.Productos.Where(p => p.IdProducto == idProducto).Select(p => p.ConvertToProductoDto());

            return Results.Ok(producto);
        }).WithTags("Producto");

        app.MapPost("/", (AppDbContext context, ProductoDto productoDto) =>
        {
            Producto producto = new()
            {
                Codigo = productoDto.Codigo,
                Barrio = productoDto.Barrio,
                Precio = productoDto.Precio,
                UrlImagen = productoDto.UrlImagen,
            };
            context.Productos.Add(producto);
            context.SaveChanges();

            return Results.Created();
        }).WithTags("Producto");

        app.MapPut("/{idProducto}", (AppDbContext context ,int idProducto, ProductoDto productoDto) =>
        {
            var producto = context.Productos.FirstOrDefault(p => p.IdProducto == idProducto);
            if (producto == null)
                return Results.BadRequest($"IdProducto {idProducto} no existe.");

            producto.Codigo = productoDto.Codigo;
            producto.Barrio = productoDto.Barrio;
            producto.Precio = productoDto.Precio;
            producto.UrlImagen = productoDto.UrlImagen;

            context.SaveChanges();

            return Results.Ok();
        }).WithTags("Producto");

        app.MapDelete("/{idProducto}", (AppDbContext context,int idProducto) =>
        {
            var producto = context.Productos.FirstOrDefault(p => p.IdProducto == idProducto);
            if (producto == null)
                return Results.BadRequest($"IdProducto {idProducto} no existe.");

            context.Productos.Remove(producto);
            context.SaveChanges();

            return Results.NoContent();
        }).WithTags("Producto");
    }
}
