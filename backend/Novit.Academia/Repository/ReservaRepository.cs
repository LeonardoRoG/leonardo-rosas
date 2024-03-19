using Mapster;
using Microsoft.EntityFrameworkCore;
using Novit.Academia.Database;
using Novit.Academia.Domain;
using Novit.Academia.Endpoints.DTO;

namespace Novit.Academia.Repository;

public interface IReservaRepository
{
    List<ReservaDto> GetReservas();
    ReservaDto GetReserva(int idReserva);
    int AddReserva(int idProducto, ReservaDto reservaDto);
    void RemoveReserva(int idReserva);
    void UpdateReserva(int idReserva, ReservaDto reservaDto);
}

public class ReservaRepository(AppDbContext context) : IReservaRepository
{
    public int AddReserva(int idProducto, ReservaDto reservaDto)
    {
        var producto = context.Productos.FirstOrDefault(x => x.IdProducto == idProducto);

        if (producto == null)
            throw new Exception($"El producto con id {idProducto} no existe");

        if (producto.Estado == Estado.Reservado)
            throw new Exception($"El producto con id {idProducto} ya tiene una reserva.");

        if (reservaDto.EstadoReserva == EstadoReserva.Ingresada)
            producto.Estado = Estado.Reservado;
        if (reservaDto.EstadoReserva == EstadoReserva.Cancelada | reservaDto.EstadoReserva == EstadoReserva.Rechazada)
            producto.Estado = Estado.Disponible;
        if (reservaDto.EstadoReserva == EstadoReserva.Aprobada)
            producto.Estado = Estado.Vendido;

        Reserva reserva = new()
        {
            Cliente = reservaDto.Cliente.Adapt<Cliente>(),
            Producto = producto,
            EstadoReserva = reservaDto.EstadoReserva
        };

        context.Reservas.Add(reserva);
        context.SaveChanges();

        return reserva.IdReserva;
    }

    public ReservaDto GetReserva(int idReserva)
    {
        var reserva = context.Reservas.Where(x => x.IdReserva == idReserva)
            .Include(x => x.Cliente)
            .Include(x => x.Producto)
            .ThenInclude(b => b.Barrio)
            .FirstOrDefault();
        return reserva.Adapt<ReservaDto>();
    }

    public List<ReservaDto> GetReservas()
    {
        var reservas = context.Reservas
            .Include(x => x.Cliente)
            .Include(x => x.Producto)
            .ThenInclude(b => b.Barrio)
            .ToList();
        return reservas.Adapt<List<ReservaDto>>();
    }

    public void RemoveReserva(int idReserva)
    {

        var reserva = context.Reservas.Where(x => x.IdReserva == idReserva)
            .Include(x => x.Producto)
            .FirstOrDefault();

        if (reserva == null)
            throw new Exception($"La reserva con id {idReserva} no existe");

        reserva.Producto.Estado = Estado.Disponible;

        context.Remove(reserva);
        context.SaveChanges();
    }

    public void UpdateReserva(int idReserva, ReservaDto reservaDto)
    {
        var reserva = context.Reservas.Where(r => r.IdReserva == idReserva)
            .Include(c => c.Cliente)
            .Include(p => p.Producto)
            .FirstOrDefault();

        if (reserva == null)
            throw new Exception($"La reserva con id {idReserva} no existe.");

        reserva.EstadoReserva = reservaDto.EstadoReserva;
        reserva.Cliente = reservaDto.Cliente.Adapt<Cliente>();

        if (reservaDto.EstadoReserva == EstadoReserva.Ingresada)
            reserva.Producto.Estado = Estado.Reservado;
        if (reservaDto.EstadoReserva == EstadoReserva.Cancelada | reservaDto.EstadoReserva == EstadoReserva.Rechazada)
            reserva.Producto.Estado = Estado.Disponible;
        if (reservaDto.EstadoReserva == EstadoReserva.Aprobada)
            reserva.Producto.Estado = Estado.Vendido;

        context.SaveChanges();
    }
}
