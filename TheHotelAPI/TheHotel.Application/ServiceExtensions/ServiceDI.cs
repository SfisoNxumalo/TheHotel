using Microsoft.Extensions.DependencyInjection;
using TheHotel.Application.Interfaces;
using TheHotel.Application.Services;

namespace TheHotel.Application.ServiceExtensions
{
    public static class ServiceDI
    {
        public static IServiceCollection AddServiceDI(this IServiceCollection services)
        {

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<IRoomServiceOrderService, RoomServiceOrderService>();
            services.AddScoped<IRoomServiceMenuService, RoomServiceMenuService>();
            services.AddScoped<IAuthService, AuthService>();

            return services;
        }
    }
}
