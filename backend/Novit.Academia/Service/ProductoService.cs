using Mapster;
using Novit.Academia.Domain;
using Novit.Academia.Endpoints.DTO;
using Novit.Academia.Repository;

namespace Novit.Academia.Service;

public interface IProductoService
{
    List<ProductoResponseDto> GetProductos();
    ProductoResponseDto GetProducto(int idProducto);
    void CreateProducto(ProductoRequestDto productoDto);
    void UpdateProducto(int idProducto, ProductoRequestDto productoDto);
    void RemoveProducto(int idProducto);
}

public class ProductoService(IProductoRepository productoRepository) : IProductoService
{
    public void CreateProducto(ProductoRequestDto productoDto)
    {
        productoRepository.AddProducto(productoDto.Adapt<ProductoDto>());
    }

    public ProductoResponseDto GetProducto(int idProducto)
    {
        return productoRepository.GetProducto(idProducto).Adapt<ProductoResponseDto>();
    }

    public List<ProductoResponseDto> GetProductos()
    {
        return productoRepository.GetProductos().Adapt<List<ProductoResponseDto>>();
    }

    public void RemoveProducto(int idProducto)
    {
        productoRepository.RemoveProducto(idProducto);
    }

    public void UpdateProducto(int idProducto, ProductoRequestDto productoDto)
    {
        productoRepository.UpdateProducto(idProducto, productoDto.Adapt<ProductoDto>());
    }
}
