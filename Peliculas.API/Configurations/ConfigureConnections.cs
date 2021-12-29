using Microsoft.EntityFrameworkCore;
using Peliculas.Infraestructure.Context;

namespace Peliculas.API.Configurations
{
    /// <summary>
    /// Configurar conexiones
    /// </summary>
    public static class ConfigureConnections
    {
        /// <summary>
        /// Adds the connection provider.
        /// </summary>
        /// <returns>The connection provider.</returns>
        /// <param name="services">Services.</param>
        /// <param name="configuration">Configuration.</param>
        public static IServiceCollection AddConnectionProvider(this IServiceCollection services, IConfiguration configuration)
        {
            string conexionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContextPool<PeliculasContext>(options => options.UseSqlServer(conexionString,
                sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 7,
                    maxRetryDelay: TimeSpan.FromSeconds(10),
                    errorNumbersToAdd: null);
                }));

            return services;
        }
    }
}
