using Microsoft.EntityFrameworkCore;
using Reservation.Entity;

namespace Reservation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container
            builder.Services.AddControllers();

            // OpenAPI/Swagger
            builder.Services.AddOpenApi();

            // Read connection string from appsettings.json
            var connectionString = builder.Configuration.GetConnectionString("ReservationConnection");

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new Exception("Connection string 'ReservationConnection' not found in appsettings.json.");
            }

            // Register DbContext
            builder.Services.AddDbContext<ReservationDbContext>(options => options.UseSqlServer(connectionString));

            var app = builder.Build();

            // Configure the HTTP request pipeline
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseCors(r => r .AllowAnyOrigin() .AllowAnyMethod() .AllowAnyHeader());
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}