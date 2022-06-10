using Locadora.Domain.Interfaces;
using Locadora.InfraData.Context;
using Locadora.InfraData.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Locadora.InfraIoC
{
    public static class DependencyInjectionAPI
    {
        public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                 b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));

            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IFilmRepository, FilmRepository>();
            services.AddScoped<IRentRepository, RentRepository>();

            return services;
        }
    }
}