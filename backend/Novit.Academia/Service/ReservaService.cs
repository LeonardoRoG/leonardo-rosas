using Mapster;
using Novit.Academia.Endpoints.DTO;
using Novit.Academia.Repository;

namespace Novit.Academia.Service;

public interface IReservaService
{
    List<ReservaResponseDto> GetReservas();
    ReservaResponseDto GetReserva(int idReserva);
    int AddReserva(int idProducto, ReservaRequestDto reservaDto);
    void RemoveReserva(int idReserva);
    void UpdateReserva(int idReserva, ReservaRequestDto reservaDto);
}

public class ReservaService(IReservaRepository reservaRepository) : IReservaService
{
    public int AddReserva(int idProducto, ReservaRequestDto reservaDto)
    {
        return reservaRepository.AddReserva(idProducto, reservaDto.Adapt<ReservaDto>());
    }

    public ReservaResponseDto GetReserva(int idReserva)
    {
        return reservaRepository.GetReserva(idReserva).Adapt<ReservaResponseDto>();
    }

    public List<ReservaResponseDto> GetReservas()
    {
        return reservaRepository.GetReservas().Adapt<List<ReservaResponseDto>>();
    }

    public void RemoveReserva(int idReserva)
    {
        reservaRepository.RemoveReserva(idReserva);
    }

    public void UpdateReserva(int idReserva, ReservaRequestDto reservaDto)
    {
        reservaRepository.UpdateReserva(idReserva, reservaDto.Adapt<ReservaDto>());
    }
}