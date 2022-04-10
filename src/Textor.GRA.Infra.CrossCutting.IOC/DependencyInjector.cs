using Microsoft.Extensions.DependencyInjection;
using Textor.GRA.Application.Automapper;
using Textor.GRA.Application.Services;
using Textor.GRA.Application.Services.Interfaces;
using Textor.GRA.Domain.Repositories;
using Textor.GRA.Domain.Services;
using Textor.GRA.Domain.Services.Interfaces;
using Textor.GRA.Infra.Data.Repositories;

namespace Textor.GRA.Infra.CrossCutting.IOC
{
    public class DependencyInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            GeneralServices(services);
            ApplicationServices(services);
            DomainServices(services);
            InfraServices(services);
        }

        private static void GeneralServices(IServiceCollection services)
        {
            services.AddSingleton(services);

            services.AddAutoMapper(typeof(MappingsProfile));
        }

        private static void ApplicationServices(IServiceCollection services)
        {
            services.AddScoped<IGraApplicationService, GraApplicationService>();
        }

        private static void DomainServices(IServiceCollection services)
        {
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IProducerService, ProducerService>();
            services.AddScoped<IStudioService, StudioService>();
        }

        private static void InfraServices(IServiceCollection services)
        {
            services.AddScoped<IMovieReadRepository, MovieReadRepository>();
            services.AddScoped<IProducerReadRepository, ProducerReadRepository>();
            services.AddScoped<IStudioReadRepository, StudioReadRepository>();

            services.AddScoped<IMovieWriteRepository, MovieWriteRepository>();
            services.AddScoped<IProducerWriteRepository, ProducerWriteRepository>();
            services.AddScoped<IStudioWriteRepository, StudioWriteRepository>();
        }
    }
}
