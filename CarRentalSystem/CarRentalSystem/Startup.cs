using CarRentalSystem.Interfaces;
using CarRentalSystem.Repositories;
using CarRentalSystem.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CarRentalSystem
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSingleton<ICarRepository, CarRepository>();
            services.AddSingleton<ICustomerRepository, CustomerRepository>();
            services.AddSingleton<IRentalRepository, RentalRepository>();

            services.AddScoped<ICarService, CarService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IRentalService, RentalService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
