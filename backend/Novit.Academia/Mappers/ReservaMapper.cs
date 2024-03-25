using Mapster;
using Novit.Academia.Domain;
using Novit.Academia.Endpoints.DTO;

namespace Novit.Academia.Mappers;

public class ReservaMapper : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Reserva, ReservaDto>()
            .Map(des => des.Cliente, src => src.Cliente)
            .Map(des => des.Producto, src => src.Producto)
            .Map(des => des.Usuario, src => src.Usuario)
            .Map(des => des.EstadoReserva, src => src.EstadoReserva);
                
        config.NewConfig<ReservaDto, ReservaResponseDto>()
            .Map(des => des.Cliente, src => src.Cliente)
            .Map(des => des.Producto, src => src.Producto);

        config.NewConfig<ReservaDto, ReservaRequestDto>()
            .Map(des => des.Cliente, src => src.Cliente)
            .Map(des => des.Usuario, src => src.Usuario);

        //config.NewConfig<>
    }
}
