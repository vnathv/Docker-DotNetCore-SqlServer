using Employee.DataAccessLayer.DBContexts;
using Employee.DataAccessLayer.Repositories;
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
             
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            services.AddDbContext<EmployeeContext>(options =>
            {
                var server = "codewithvijay1";
                var port = "1433";
                var database = "Employee";
                var user = "SA";
                var password = "TestP@ssw0rd";

                options.UseSqlServer(
                    $"Server={server},{port};Initial Catalog={database};User ID={user};Password={password}", b => b.MigrationsAssembly("Employee.API"));
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
