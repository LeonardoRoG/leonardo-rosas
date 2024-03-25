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
    void CancelReserva(int idReserva);
    void RejectReserva(int idReserva);
    void ApproveReserva(int idReserva);
    void UpdateReserva(int idReserva, ReservaDto reservaDto);
}

public class ReservaRepository(AppDbContext context) : IReservaRepository
{
    public int AddReserva(int idProducto, ReservaDto reservaDto)
    {
        var producto = context.Productos.Where(x => x.IdProducto == idProducto)
                                        .Include(x => x.Barrio)
                                        .FirstOrDefault();

        if (producto == null)
            throw new Exception($"El producto con id {idProducto} no existe");

        // Si el producto ya está reservado lanza una excepción
        if (producto.Estado == Estado.Reservado)
            throw new Exception($"El producto con id {idProducto} ya tiene una reserva.");

        // Busco las reservas hechas por el usuario y si tiene más de 3 lanza una excepción
        var reservas = context.Reservas.Include(x => x.Usuario)
                                       .Where(x => x.Usuario == reservaDto.Usuario.Adapt<Usuario>())
                                       .Where(x => x.EstadoReserva == EstadoReserva.Ingresada)
                                       .ToList();

        if (reservas.Count > 3)
            throw new Exception($"El usuario ya tiene 3 reservas ingresadas.");

        reservaDto.EstadoReserva = EstadoReserva.Ingresada;
        producto.Estado = Estado.Reservado;

        // Busca el barrio de la bd con nombre coincidente al que pertenece el producto
        // Luego cuenta cuántos productos de ese barrio están disponibles
        // Si hay uno solo disponible o su precio es menor a 100k y se solicita la aprobacion, ésta se apureba automaticamente
        var barrios = context.Barrios.Include(x => x.Productos).ToList();
        foreach ( var barrio in barrios)
        {
            if (barrio.Nombre == producto.Barrio.Nombre)
            {
                var barriosDisponibles = 0;
                foreach (var productoBarrio in barrio.Productos)
                {
                    if (productoBarrio.Estado == Estado.Disponible)
                        barriosDisponibles++;
                }
                if (reservaDto.SolicitarAprobacion && barriosDisponibles == 1 || reservaDto.SolicitarAprobacion && producto.Precio < 100000)
                {
                    reservaDto.EstadoReserva = EstadoReserva.Aprobada;
                    producto.Estado = Estado.Vendido;
                    break;
                }
            }
        }

        Reserva reserva = new()
        {
            Cliente = reservaDto.Cliente.Adapt<Cliente>(),
            Producto = producto,
            EstadoReserva = reservaDto.EstadoReserva,
            SolicitarAprobacion = reservaDto.SolicitarAprobacion,
            Usuario = reservaDto.Usuario.Adapt<Usuario>(),
        };

        context.Reservas.Add(reserva);
        context.SaveChanges();

        return reserva.IdReserva;
    }

    public ReservaDto GetReserva(int idReserva)
    {
        var reserva = context.Reservas.Where(x => x.IdReserva == idReserva)
            .Include(x => x.Cliente)
            .Include(x => x.Usuario)
            .Include(x => x.Producto)
            .ThenInclude(b => b.Barrio)
            .FirstOrDefault();
        return reserva.Adapt<ReservaDto>();
    }

    public List<ReservaDto> GetReservas()
    {
        var reservas = context.Reservas
            .Include(x => x.Cliente)
            .Include (x => x.Usuario)
            .Include(x => x.Producto)
            .ThenInclude(b => b.Barrio)
            .ToList();
        return reservas.Adapt<List<ReservaDto>>();
    }

    public void CancelReserva(int idReserva)
    {
        var reserva = context.Reservas.Where(x => x.IdReserva == idReserva)
            .Include(x => x.Producto)
            .FirstOrDefault();

        if (reserva == null)
            throw new Exception($"La reserva con id {idReserva} no existe");

        reserva.Producto.Estado = Estado.Disponible;
        reserva.EstadoReserva = EstadoReserva.Cancelada;

        context.SaveChanges();
    }

    public void RejectReserva(int idReserva)
    {
        var reserva = context.Reservas.Where(x => x.IdReserva == idReserva)
            .Include(x => x.Producto)
            .FirstOrDefault();

        if (reserva == null)
            throw new Exception($"La reserva con id {idReserva} no existe");

        reserva.Producto.Estado = Estado.Disponible;
        reserva.EstadoReserva = EstadoReserva.Rechazada;

        context.SaveChanges();
    }
    
    public void ApproveReserva(int idReserva)
    {
        var reserva = context.Reservas.Where(x => x.IdReserva == idReserva)
            .Include(x => x.Producto)
            .FirstOrDefault();

        if (reserva == null)
            throw new Exception($"La reserva con id {idReserva} no existe");

        reserva.Producto.Estado = Estado.Vendido;
        reserva.EstadoReserva = EstadoReserva.Aprobada;

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
