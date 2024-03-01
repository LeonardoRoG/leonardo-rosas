using Novit.Academia.Domain;
using Novit.Academia.Endpoints.DTO;

namespace Novit.Academia
{
    public static class ExtensionMethods
    {
        public static ProductoDto ConvertToProductoDto(this Producto p) =>
            new(p.Nombre, p.Descripcion, p.Precio, p.UrlImagen, p.Stock);
    }
}
