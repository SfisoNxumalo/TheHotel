using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using TheHotel.Application.Interfaces;
using TheHotel.Application.ServiceExtensions;
using TheHotel.Infrastructure.DatabaseContext;
using TheHotel.Infrastructure.Extension;
using TheHotel.Infrastructure.Integration.GeminiService;
using TheHotel.Infrastructure.Seeding;
using TheHotel.Infrastructure.SignalR;
using TheHotelAPI.SignalR;

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
                        .WithOrigins("http://localhost:5173", "http://localhost:5174", "")
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });

            // Add services to the container.

            builder.Services.AddHttpClient<GeminiService>();
            builder.Services.AddControllers();
            builder.Services.AddSignalR();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                var jwtSecurityScheme = new OpenApiSecurityScheme
                {
                    BearerFormat = "JWT",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Scheme = JwtBearerDefaults.AuthenticationScheme,
                    Type = SecuritySchemeType.Http,
                    Description = "Enter your JWT access token",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };

                options.AddSecurityDefinition("Bearer", jwtSecurityScheme);
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {jwtSecurityScheme, Array.Empty<string>() }
                });
            });

            //Add DI for Infrastructure layer
            builder.Services.AddInfrastructureDI();
            builder.Services.AddScoped<IRealTimeNotifier, RealtimeNotifier>();

            //Add DI for Service Layer
            builder.Services.AddServiceDI();

            builder.Services.AddDbContext<HotelContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = builder.Configuration["JwtConfig:Issuer"],
                    ValidAudience = builder.Configuration["JwtConfig:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtConfig:AccessTokenSecret"]!)),
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true
                };
            });

            builder.Services.AddAuthorization();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            using var scope = app.Services.CreateScope();
            var seeder = new DatabaseSeeder(scope.ServiceProvider.GetRequiredService<HotelContext>());
            seeder.SeedAsync();

            app.MapGet("/", () => Results.Ok(new
            {
                message = "The Hotel API is running",
                status = "success",
                version = "v1.0"
            }));

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseCors("AllowFrontend");
            app.MapHub<RealtimeHub>("/hubs/hotel");

            app.MapControllers();

            app.Run();
        }
    }
}
