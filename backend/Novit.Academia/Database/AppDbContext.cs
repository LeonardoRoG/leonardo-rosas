using Microsoft.EntityFrameworkCore;
using Novit.Academia.Domain;

namespace Novit.Academia.Database
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Producto> Productos { get; set; }

        public DbSet<Reserva> Reservas { get; set; }

        public DbSet<Barrio> Barrios { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Rol> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //    modelBuilder.Entity<Producto>().HasData(
            //        new Producto
            //        {
            //            IdProducto = 1,
            //            Codigo = "H3730BAN125",
            //            Barrio = new Barrio() { IdBarrio = 1, Nombre = "San Martin" },
            //            Precio = 72000,
            //            Estado = Estado.Disponible,
            //        },
            //        new Producto
            //        {
            //            IdProducto = 2,
            //            Codigo = "H4500RSA",
            //            Barrio = new Barrio() { IdBarrio = 2, Nombre = "Belgrano" },
            //            Precio = 90000,
            //            Estado = Estado.Disponible,
            //        },
            //        new Producto
            //        {
            //            IdProducto = 3,
            //            Codigo = "HFJS9930R",
            //            Barrio = new Barrio() { IdBarrio = 3, Nombre = "Palermo" },
            //            Precio = 120000,
            //            Estado = Estado.Disponible,
            //        }
            //        );
            modelBuilder.Entity<Rol>().HasData(
                new Rol
                {
                    Id = Guid.NewGuid(),
                    Name = "administrador"
                },
                new Rol
                {
                    Id = Guid.NewGuid(),
                    Name = "comercial"
                },
                new Rol
                {
                    Id = Guid.NewGuid(),
                    Name = "vendedor"
                }
                );
        }

    }
}
