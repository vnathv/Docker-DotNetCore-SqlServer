using System;
using Employee.DataAccessLayer.DBContexts;
using Employee.DataAccessLayer.Repositories;
using Employee.Provider;
using Employee.Provider.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Employee.API
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

            services.AddScoped<IEmployeeProvider, EmployeeProvider>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            services.AddDbContext<EmployeeContext>(options =>
            {              
                var server = Configuration["ServerName"];
                var port = "1433";
                var database = Configuration["Database"];
                var user = Configuration["UserName"];
                var password = Configuration["Password"];

                options.UseSqlServer(
                    $"Server={server},{port};Initial Catalog={database};User ID={user};Password={password}",
                    sqlServer => sqlServer.MigrationsAssembly("Employee.API"));
            }); 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
