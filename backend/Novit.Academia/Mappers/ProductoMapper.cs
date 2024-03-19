using Mapster;
using Novit.Academia.Domain;
using Novit.Academia.Endpoints.DTO;

namespace Novit.Academia.Mappers;

public class ProductoMapper : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Producto, ProductoDto>()
            .Map(des => des.IdProducto, src => src.IdProducto)
            .Map(des => des.Codigo, src => src.Codigo)
            .Map(des => des.Barrio, src => src.Barrio)
            .Map(des => des.Precio, src => src.Precio)
            .Map(des => des.UrlImagen, src => src.UrlImagen)
            .Map(des => des.Estado, src => src.Estado);

        config.NewConfig<ProductoDto, ProductoResponseDto>()
            .Map(des => des.IdProducto, src => src.IdProducto)
            .Map(des => des.Codigo, src => src.Codigo)
            .Map(des => des.Barrio, src => src.Barrio)
            .Map(des => des.Precio, src => src.Precio)
            .Map(des => des.UrlImagen, src => src.UrlImagen)
            .Map(des => des.Estado, src => src.Estado);

        config.NewConfig<Barrio, BarrioDto>()
            .Map(des => des.IdBarrio, src => src.IdBarrio)
            .Map(des => des.Nombre, src => src.Nombre)
            ;

        config.NewConfig<BarrioDto, BarrioResponseDto>()
            .Map(des => des.IdBarrio, src => src.IdBarrio)
            .Map(des => des.Nombre, src => src.Nombre)
            ;
    }
}