using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MSG.SistemaVentas.Domain.Entities;

namespace MSG.SistemaVentas.Infrastructure.Persistence
{
    public class VentasDbContext: DbContext
    {
        public VentasDbContext(DbContextOptions<VentasDbContext> options) : base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Venta> Ventas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(VentasDbContext).Assembly);
        }
    }
}
