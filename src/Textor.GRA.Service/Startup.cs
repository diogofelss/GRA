using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Linq;
using System.Reflection;
using Textor.GRA.Application.Automapper;
using Textor.GRA.Domain.Entities;
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

            var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetService<GeneralContext>();
            ImportarExcel(context);
        }

        private static void ImportarExcel(GeneralContext context)
        {
            if (context.Movies.AsQueryable().Where(c => c.Title == "Star Wars").Any())
                return;

            var movie = new Movie
            {
                ID = Guid.NewGuid(),
                Year = 1977,
                Title = "Star Wars"
            };

            var ret1 = context.Movies.Add(movie);

            var ret2 = context.SaveChanges();
        }
    }
}
