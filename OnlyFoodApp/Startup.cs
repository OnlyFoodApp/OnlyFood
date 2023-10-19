using Domain.Common;
using Domain.Common.Interface;
using Persistence.Contexts;
using System.Reflection;
using Microsoft.EntityFrameworkCore;


namespace OnlyFoodApp
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IDomainEventDispatcher, DomainEventDispatcher>();
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())); // Replace with your assembly containing handlers
            //services.AddMediatR(typeof(CreateAccountCommand));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
