using Novit.Academia.Domain;
using Novit.Academia.Endpoints.DTO;

namespace Novit.Academia
{
    public static class ExtensionMethods
    {
        public static ProductoDto ConvertToProductoDto(this Producto p) =>
            new(p.Nombre, p.Descripcion, p.Precio, p.UrlImagen, p.Stock);

        public static Producto ConvertToProducto(this ProductoDto p) =>
            new(){
                Nombre = p.Nombre,
                Precio = p.Precio,
                UrlImagen = p.UrlImagen,
                Stock = p.Stock,
                Descripcion = p.Descripcion
            };

    }
}
