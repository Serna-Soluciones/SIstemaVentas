using Serilog;
using Microsoft.EntityFrameworkCore;
using MSG.SistemaVentas.Infrastructure.Persistence;
using MSG.SistemaVentas.API.Middlewares;
using MSG.SistemaVentas.Application;
using MSG.SistemaVentas.API.Extensions;

namespace MSG.SistemaVentas.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.File("Logs/SistemaVentas.log", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            builder.Host.UseSerilog();

            builder.Configuration
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            var connectionString = builder.Configuration.GetConnectionString("PostgresConnection");
            // Add services to the container.

            Console.WriteLine($"Connection string: {connectionString}");

            builder.Services.AddDbContext<VentasDbContext>(options => options.UseNpgsql(connectionString));

            builder.Services.AddJwtAuthentication(builder.Configuration);

            builder.Services.AddApplicationServices();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(options => {
                options.AddPolicy("CorsPolicy", policy =>
                {
                    policy.WithOrigins("http://localhost:31066")
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

            var app = builder.Build();

            app.UseCors("CorsPolicy");

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "MSG.SistemaVentas API v1");
                    c.RoutePrefix = string.Empty;
                });
            }

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
