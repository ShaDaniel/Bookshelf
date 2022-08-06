using Bookshelf.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

namespace Bookshelf
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var configBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");
            builder.Services.AddSingleton(configBuilder.Build());
            builder.Services.AddSingleton<IBookRepository, BookRepository>();
            builder.Host.ConfigureLogging(logging =>
            {
                logging.ClearProviders();
                logging.AddNLog();
            });

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}