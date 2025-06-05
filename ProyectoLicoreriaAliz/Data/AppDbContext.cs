using Microsoft.EntityFrameworkCore;
using ProyectoLicoreriaAliz.Models;
using System.Collections.Generic;

namespace Examen_T1.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Entradas_productos> Entradas_Productos { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Purchase_detail> Purchase_Detail { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Provider_detalle_producto> Provider_Detalle_Producto { get; set; }
        public DbSet<Detalle_entrada> Detalle_Entradas { get; set; }
        public DbSet<Refund> Refunds { get; set; }
        public DbSet<Clients> Clients { get; set; }
        public DbSet<Role> Role { get; set; }




    }
}
