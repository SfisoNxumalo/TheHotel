using Microsoft.Extensions.DependencyInjection;
using TheHotel.Domain.Interfaces;
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

            return services;
        }
    }
}
