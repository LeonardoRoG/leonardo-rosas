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

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Barrio>()
        //        .HasMany(e => e.Productos)
        //        .WithOne(e => e.Barrio)
        //        .HasForeignKey(e => e.IdBarrio)
        //        .IsRequired();

        //    base.OnModelCreating(modelBuilder);
        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Barrio>().HasData(
        //        new Barrio
        //        {
        //            IdBarrio = 1,
        //            Nombre = "San Martin",
        //        });

        //    modelBuilder.Entity<Producto>().HasData(
        //        new Producto
        //        {
        //            IdProducto = 1,
        //            Codigo = "H3730BAN125",
        //            Barrio = ,
        //            Precio = 7200000,
        //            Estado = Estado.Disponible,
        //        },
        //        new Producto
        //        {
        //            IdProducto = 2,
        //            Codigo = "H4500RSA",
        //            Barrio = new Barrio() { IdBarrio = 2, Nombre = "Belgrano" },
        //            Precio = 9000000,
        //            Estado = Estado.Disponible,
        //        },
        //        new Producto
        //        {
        //            IdProducto = 3,
        //            Codigo = "HFJS9930R",
        //            Barrio = new Barrio() { IdBarrio = 3, Nombre = "Rosario" },
        //            Precio = 22000000,
        //            Estado = Estado.Disponible,
        //        }
        //        );
        //}

    }
}
