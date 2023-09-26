

using Application.Extensions;
using Infrastructure.Extensions;
using Persistence.Extensions;

namespace OnlyFoodApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            builder.Configuration.AddEnvironmentVariables();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            // Add services to the container.
            builder.Services.AddApplicationLayer();
            builder.Services.AddInfrastructureLayer();
            builder.Services.AddPersistenceLayer(builder.Configuration);
            builder.Services.AddRouting(options =>
            {
                options.LowercaseUrls = true; // Convert URLs to lowercase
            });
            builder.Services.AddControllers();
            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();
            

            // Configure the HTTP request pipeline.

            //app.UseSwagger();
            //app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args)
            => Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(
                    webBuilder => webBuilder.UseStartup<Startup>());
    }
}