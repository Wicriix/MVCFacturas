using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MVCFacturas.ExternalConnections.DbContexts;
using MVCFacturas.ExternalConnections.GenericRepository;
using MVCFacturas.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFacturas
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "MVCFacturas",
                    Version = "v1",
                    Description = "Api desarrollada en .Net 5",
                    License = new OpenApiLicense
                    {
                        Name = "Use under LICX"
                    }
                });

                c.EnableAnnotations();
            });
            services.AddDbContext<MVCFacturasContext>(options =>
            {
                options.UseSqlServer(
                    connectionString: Configuration.GetConnectionString("MVCFacturasConnection"),
                    sqlServerOptionsAction: sqlOpt =>
                    {
                        sqlOpt.CommandTimeout(7200);
                        sqlOpt.EnableRetryOnFailure();
                    }
                    );
            }, ServiceLifetime.Transient);
            services.AddCors(options =>
             {
                 options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
             });

            #region servicios 
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient(typeof(FacturasService)); 
            services.AddTransient(typeof(TiposDePagoService));
            services.AddTransient(typeof(ProductosService)); 
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var Context = scope.ServiceProvider.GetRequiredService<MVCFacturasContext>();
                Context.Database.Migrate();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MVCFacturas v1"));

            app.UseCors("CorsPolicy");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
