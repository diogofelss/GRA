using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Textor.GRA.Application.DTOs;
using Textor.GRA.Application.Services.Interfaces;
using Textor.GRA.Domain.Framework.Extensions;
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
            var dataBase = Configuration.GetConnectionString("Default");
            services.AddDbContext<GeneralContext>(opt => opt.UseSqlite(dataBase));

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

        private void ImportarExcel(IApplicationBuilder app)
        {
            Task.Factory.StartNew(async () =>
            {
                using var scope = app.ApplicationServices.CreateAsyncScope();
                var csvApplicationService = scope.ServiceProvider.GetService<ICSVApplicationService>();

                var lista = new List<CsvDTO>();

                var csvPath = Configuration.GetSection("CSV").GetValue(typeof(string),"Path").ToString();
                using (var reader = new StreamReader(csvPath))
                {
                    List<string> listA = new();
                    List<string> listB = new();

                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var values = line.Split(';');

                        if (!int.TryParse(values[0], out int integer))
                            continue;

                        listA.Add(values[0]);
                        listB.Add(values[1]);

                        var csvLine = new CsvDTO
                        {
                            Year = values[0].ToInt32(),
                            Title = values[1],
                            Studios = values[2],
                            Producers = values[3],
                            Winner = values[4] == "yes"
                        };

                        lista.Add(csvLine);
                    }
                }

                await csvApplicationService.Import(lista);
            });
        }
    }
}
