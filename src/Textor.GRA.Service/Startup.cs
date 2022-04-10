using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Textor.GRA.Application.DTOs;
using Textor.GRA.Application.Services.Interfaces;
using Textor.GRA.Infra.CrossCutting.IOC;
using Textor.GRA.Infra.Data.Context;

namespace Textor.GRA.Service
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<GeneralContext>(opt => opt.UseSqlite(@"Data Source=Banco.db"));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            });

            DependencyInjector.RegisterServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            ImportarExcel(app);
        }

        private static void ImportarExcel(IApplicationBuilder app)
        {
            Task.Factory.StartNew(async () =>
            {
                using var scope = app.ApplicationServices.CreateAsyncScope();
                var csvApplicationService = scope.ServiceProvider.GetService<IMovieApplicationService>();

                var movie1 = new CsvDTO
                {
                    Year = 1980,
                    Title = "Can't Stop the Music",
                    Studios = "Universal Studios, Associated Film Distribution",
                    Producers = "Kevin Costner, Lawrence Kasdan and Jim Wilson"
                };

                var movie2 = new CsvDTO
                {
                    Year = 1980,
                    Title = "Cruising",
                    Studios = "Lorimar Productions, United Artists",
                    Producers = "Jerry Weintraub"
                };

                var movie3 = new CsvDTO
                {
                    Year = 1980,
                    Title = "The Formula",
                    Studios = "MGM, United Artists",
                    Producers = "Steve Shagan"
                };

                var list = new List<CsvDTO>
                {
                    movie1,
                    movie2,
                    movie3
                };

                await csvApplicationService.Import(list);
            });
        }
    }
}
