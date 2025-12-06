using Microsoft.Extensions.DependencyInjection;
using TheHotel.Domain.Interfaces.Integrations;
using TheHotel.Domain.Interfaces.Repositories;
using TheHotel.Infrastructure.Integration.Auth;
using TheHotel.Infrastructure.Integration.GeminiService;
using TheHotel.Infrastructure.Repositories;

namespace TheHotel.Infrastructure.Extension
{
    // Centralised Infrastructure dependency injection registration.
    // provide a single, organised place for configuring Infrastructure
    // dependencies. This extension method keeps the service configuration
    // clean and separated from the main Program.cs file.
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

            services.AddScoped<IAIContentService, GeminiService>();

            services.AddScoped<ITokenService, JwtService>();

            return services;
        }
    }
}
