using Microsoft.EntityFrameworkCore;
using Novit.Academia.Domain;

namespace Novit.Academia.Database
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        // Forma Clasica con constructor
        //public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        //{

        //}

        public DbSet<Producto> Productos { get; set; }

        public DbSet<ItemCarrito> Items { get; set; }

        public DbSet<Carrito> Carritos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>().HasData(
                new Producto
                {
                    IdProducto = 1,
                    Nombre = "Fideo",
                    Precio = 550,
                    Stock = 400
                },
                new Producto
                {
                    IdProducto = 2,
                    Nombre = "Arroz",
                    Precio = 900,
                    Stock = 350
                },
                new Producto
                {
                    IdProducto = 3,
                    Nombre = "Raviol",
                    Precio = 1600,
                    Stock = 120
                }
                );
        }
    }
}
