using Mapster;
using Microsoft.EntityFrameworkCore;
using Novit.Academia.Database;
using Novit.Academia.Domain;
using Novit.Academia.Endpoints.DTO;

namespace Novit.Academia.Repository;

public interface IProductoRepository
{
    List<ProductoDto> GetProductos();
    ProductoDto GetProducto(int idProducto);
    void AddProducto(ProductoDto productoDto);
    void UpdateProducto(int idProducto ,ProductoDto productoDto);
    void RemoveProducto(int idProducto);
}

public class ProductoRepository(AppDbContext context) : IProductoRepository
{
    public void AddProducto(ProductoDto productoDto)
    {
        var barrios = context.Barrios.ToList();
        Barrio barrioNuevo = productoDto.Barrio.Adapt<Barrio>();

        // Busca el nombre del barrio en la bd
        // En caso de encontrarlo usa ese barrio en la definición del producto
        // Caso contrario crea un barrio con ese nombre.

        foreach (var barrio in barrios)
        {
            if (barrio.Nombre == productoDto.Barrio.Nombre)
            {
                barrioNuevo = barrio;
                break;
            } 
        }

        Producto producto = new()
        {
            Codigo = productoDto.Codigo,
            Barrio = barrioNuevo,
            Precio = productoDto.Precio,
            UrlImagen = productoDto.UrlImagen,
            Estado = productoDto.Estado,
        };

        context.Add(producto);
        context.SaveChanges();
    }

    public ProductoDto GetProducto(int idProducto)
    {
        var producto = context.Productos
            .Where(x => x.IdProducto == idProducto)
            .Include(x => x.Barrio)
            .SingleOrDefault();

        return producto.Adapt<ProductoDto>();
    }

    public List<ProductoDto> GetProductos()
    {
        var productos = context.Productos
            .Include(x => x.Barrio)
            .ToList();

        return productos.Adapt<List<ProductoDto>>();
    }

    public void RemoveProducto(int idProducto)
    {
        var producto = context.Productos.FirstOrDefault(p => p.IdProducto == idProducto);
        if (producto == null)
            throw new Exception($"El producto con id {idProducto} no existe.");

        context.Productos.Remove(producto);
        context.SaveChanges();
    }

    public void UpdateProducto(int idProducto, ProductoDto productoDto)
    {
        var barrios = context.Barrios.ToList();
        Barrio barrioNuevo = productoDto.Barrio.Adapt<Barrio>();

        foreach (var barrio in barrios)
        {
            if (barrio.Nombre == productoDto.Barrio.Nombre)
            {
                barrioNuevo = barrio;
                break;
            }
        }

        var producto = context.Productos.Where(x => x.IdProducto == idProducto)
            .Include(x => x.Barrio)
            .SingleOrDefault();

        if (producto == null)
            throw new Exception($"El producto con id {idProducto} no existe.");

        producto.Codigo = productoDto.Codigo;
        producto.Barrio = barrioNuevo;
        producto.Precio = productoDto.Precio;
        producto.UrlImagen = productoDto.UrlImagen;
        producto.Estado = productoDto.Estado;

        context.SaveChanges();
    }
}
