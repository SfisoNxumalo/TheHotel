using Microsoft.Extensions.DependencyInjection;
using TheHotel.Application.Interfaces;
using TheHotel.Application.Services;

namespace TheHotel.Application.ServiceExtensions
{
    // Centralised Application-layer dependency injection registration.
    // This provides a single, organised place for configuring Application
    // services and keeps the service setup clean and separate from the
    // main Program.cs file.
    public static class ServiceDI
    {
        public static IServiceCollection AddServiceDI(this IServiceCollection services)
        {

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<IRoomServiceOrderService, RoomServiceOrderService>();
            services.AddScoped<IRoomServiceMenuService, RoomServiceMenuService>();
            services.AddScoped<IAuthService, AuthService>();

            services.AddScoped<ContentManager>();

            return services;
        }
    }
}
