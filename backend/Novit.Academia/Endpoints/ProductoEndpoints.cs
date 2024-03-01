using Carter;
using Microsoft.AspNetCore.Http.HttpResults;
using Novit.Academia.Database;
using Novit.Academia.Domain;
using Novit.Academia.Endpoints.DTO;

namespace Novit.Academia.Endpoints;

public class ProductoEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder routes)
    {
        var app = routes.MapGroup("/api/Producto");

        // GET - Obtener lista de productos
        app.MapGet("/", (AppDbContext context) =>
        {
            var productos = context.Productos.Select(p => p.ConvertToProductoDto());
            return Results.Ok(productos);
        }).WithTags("Producto");

        // GET - Obtener un producto según su id
        app.MapGet("/{idProducto}", (AppDbContext context,int idProducto) =>
        {
            var producto = context.Productos.Where(p => p.IdProducto == idProducto).Select(p => p.ConvertToProductoDto());
            return Results.Ok(producto);
        }).WithTags("Producto");

        // POST - Crear un producto nuevo
        app.MapPost("/", (AppDbContext context, ProductoDto productoDto) =>
        {
            Producto producto = new() { 
                Nombre = productoDto.Nombre,
                Descripcion = productoDto.Descripcion,
                Precio = productoDto.Precio,
                Stock = productoDto.Stock,
                UrlImagen = productoDto.UrlImagen,
            };

            context.Productos.Add(producto);
            context.SaveChanges();
            return Results.Created();
        }).WithTags("Producto");

        // PUT - Modificar un producto
        app.MapPut("/{idProducto}", (AppDbContext context,int idProducto, ProductoDto productoDto) =>
        {
            var producto = context.Productos.FirstOrDefault(p => p.IdProducto == idProducto);

            if (producto == null)
                return Results.BadRequest();

            producto.Nombre = productoDto.Nombre;
            producto.Descripcion = productoDto.Descripcion;
            producto.Stock = productoDto.Stock;
            producto.UrlImagen = productoDto.UrlImagen;
            producto.Precio = productoDto.Precio;

            context.SaveChanges();

            return Results.Ok();
        }).WithTags("Producto");

        // DELETE - Eliminar un producto
        app.MapDelete("/{idProducto}", (AppDbContext context ,int idProducto) =>
        {
            var producto = context.Productos.FirstOrDefault(p => p.IdProducto == idProducto);

            if (producto == null)
                return Results.BadRequest();

            context.Productos.Remove(producto);
            context.SaveChanges();

            return Results.NoContent();
        }).WithTags("Producto");
    }
}
