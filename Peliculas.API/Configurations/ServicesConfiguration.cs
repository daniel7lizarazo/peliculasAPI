using Peliculas.Application.Implementations;
using Peliculas.Application.Interfaces;
using Peliculas.Domain.Attributes;
using Peliculas.Domain.Entities;
using Peliculas.Domain.Repository;
using Peliculas.Infraestructure;
using System.Reflection;

namespace Peliculas.API.Configurations
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddCorsConfiguration(this IServiceCollection services) =>
         services.AddCors(options =>
         {

             options.AddPolicy(
              "AllowOrigin",
              builder =>
              builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());


         });

        public static IServiceCollection AddConfigureService(this IServiceCollection services)
        {
            var entities = typeof(Entity<>).Assembly.GetTypes().Where(it => it.IsClass && !it.IsAbstract && it.GetCustomAttribute<EntityAttribute>() != null);
            //Auto-Inyección de Servicios para Entities
            foreach (var clase in entities)
            {
                var typeBaseId = clase.GetProperty("Id").PropertyType;
                services.AddTransient(typeof(ICrudService<,>).MakeGenericType(clase, typeBaseId),
                        typeof(CrudService<,>).MakeGenericType(clase, typeBaseId));
                services.AddTransient(typeof(IRepository<,>).MakeGenericType(clase, typeBaseId),
                    typeof(MemoryRepository<,>).MakeGenericType(clase, typeBaseId));
            }
            //Servicios
            services.AddTransient<IImagenPeliculaService, ImagenPeliculaService>();

            services.AddTransient<IAlmacenarArchivos, AlmacenadorArchivosLocal>();

            return services;
        }
    }
}
