using Microsoft.Extensions.DependencyInjection;
using MSG.SistemaVentas.API.Middlewares;
using MSG.SistemaVentas.Application.Interfaces;
using MSG.SistemaVentas.Application.Services;
using MSG.SistemaVentas.Domain.Entities;
using MSG.SistemaVentas.Domain.Interfaces;
using MSG.SistemaVentas.Infrastructure.Persistence.Repositories;

namespace MSG.SistemaVentas.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services
                .AddScoped<IAuthRepository, AuthRepository>()
                .AddScoped<IJwtService, JwtService>()
                .AddScoped<IProductoService, ProductoService>()
                .AddScoped<IRepository<Producto>, ProductoRepository>()
                .AddScoped<IVentaService, VentaService>()
                .AddScoped<IRepository<Venta>, VentaRepository>();
            return services;
        }
    }
}
