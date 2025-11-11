using Microsoft.EntityFrameworkCore;
using TheHotel.Application.ServiceExtensions;
using TheHotel.Infrastructure.DatabaseContext;
using TheHotel.Infrastructure.Extension;

namespace TheHotelAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowFrontend",
                    policy => policy
                        .WithOrigins("http://localhost:5173", "")
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //Add DI for Infrastructure layer
            builder.Services.AddInfrastructureDI();

            //Add DI for Service Layer
            builder.Services.AddServiceDI();

            builder.Services.AddDbContext<HotelContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //using var scope = app.Services.CreateScope();
            //var seeder = new DatabaseSeeder(scope.ServiceProvider.GetRequiredService<HotelContext>());
            // seeder.SeedAsync();

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseCors("AllowFrontend");


            app.MapControllers();

            app.Run();
        }
    }
}
