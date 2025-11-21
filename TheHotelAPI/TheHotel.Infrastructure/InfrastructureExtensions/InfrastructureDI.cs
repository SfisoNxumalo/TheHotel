using Microsoft.Extensions.DependencyInjection;
using TheHotel.Domain.Interfaces.Integrations;
using TheHotel.Domain.Interfaces.Repositories;
using TheHotel.Infrastructure.Integration.Auth;
using TheHotel.Infrastructure.Repositories;

namespace TheHotel.Infrastructure.Extension
{
    public static class InfrastructureDI
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<IRoomServiceOrderRepository, RoomServiceOrderRepository>();
            services.AddScoped<IRoomServiceMenuRepository, RoomServiceMenuRepository>();
            services.AddScoped<IAuthRepository, AuthRepository>();

            services.AddScoped<ITokenService, JwtService>();

            return services;
        }
    }
}
