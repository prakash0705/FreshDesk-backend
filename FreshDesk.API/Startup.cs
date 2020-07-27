using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FreshDesk.Entities.Models;
using Microsoft.EntityFrameworkCore;
using FreshDesk.Repository.Repository;

namespace FreshDesk.API
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
            string connectionString = Configuration["ConnectionStrings:dbconnection"];
            services.AddDbContext<FreshDeskDbContext>(a => a.UseSqlServer(connectionString,b=>b.MigrationsAssembly("FreshDesk.Entities")));
            services.AddScoped<IRegisterRepository,RegisterRepository>();
            services.AddScoped<ITicketRepository, TicketRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddSwaggerGen(a =>
            {
                a.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "FreshDesk Rest Api",
                    Version = "v1"
                });
            });
            services.AddCors(option =>
               {
                   option.AddDefaultPolicy(
                       builder =>
                       {
                           builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                       });
               });
      

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(a =>
            {
                a.SwaggerEndpoint("/swagger/v1/swagger.json", "FreshDesk Rest Api");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
