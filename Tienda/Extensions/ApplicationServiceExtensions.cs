using Tienda.Domain.Repositories;
using Tienda.Infraestructure.Repositories;

namespace Tienda.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyOrigin());
            });
        public static void AddApplicationServices(this IServiceCollection services)
        {
            /*
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>)); //Sintaxis para agregar un repo generico
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IBrandRepository, BrandRepository>();
            */

            // La unidad de trabajo es mi contenedor de los repositorios ahora
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
