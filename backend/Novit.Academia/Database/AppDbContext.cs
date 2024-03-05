using Microsoft.EntityFrameworkCore;
using Novit.Academia.Domain;

namespace Novit.Academia.Database
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Producto> Productos { get; set; }

        public DbSet<Reserva> Reservas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>().HasData(
                new Producto
                {
                    IdProducto = 1,
                    Codigo = "H3730BAN125",
                    Barrio = "San Martin",
                    Precio = 7200000
                },
                new Producto
                {
                    IdProducto = 2,
                    Codigo = "H3500BSN322",
                    Barrio = "Belgrano",
                    Precio = 16500000
                },
                new Producto
                {
                    IdProducto = 3,
                    Codigo = "H2575CPA777",
                    Barrio = "Pellegrini",
                    Precio = 14000000
                });
        }

    }
}
