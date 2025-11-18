using Bogus;
using Microsoft.EntityFrameworkCore;
using TheHotel.Domain.Entities;
using TheHotel.Infrastructure.DatabaseContext;

namespace TheHotel.Infrastructure.Seeding
{
    public class DatabaseSeeder
    {
        private readonly HotelContext _context;
        private readonly Faker _faker = new Faker();

        public DatabaseSeeder(HotelContext context)
        {
            _context = context;
        }

        public async Task SeedAsync(int userCount = 10, int staffCount = 3, int roomCount = 10)
        {
            if (await _context.Users.AnyAsync()) return; // already seeded

            // 1. Seed Users
            var users = new List<UserEntity>();
            for (int i = 0; i < userCount; i++)
            {
                users.Add(new UserEntity
                {
                    Id = Guid.NewGuid(),
                    FullName = _faker.Name.FullName(),
                    Email = _faker.Internet.Email(),
                    PhoneNumber = _faker.Phone.PhoneNumber(),
                    PasswordHash = ""
                });
            }
            await _context.Users.AddRangeAsync(users);

            // 2. Seed Staff
            var staff = new List<StaffEntity>();
            for (int i = 0; i < staffCount; i++)
            {
                staff.Add(new StaffEntity
                {
                    Id = Guid.NewGuid(),
                    FullName = _faker.Name.FullName(),
                    Role = "Receptionist",
                    Email = _faker.Internet.Email(),
                    PhoneNumber = _faker.Phone.PhoneNumber(),
                    PasswordHash = ""
                });
            }
            await _context.Staff.AddRangeAsync(staff);

            // 3. Seed Rooms and Devices
            var rooms = new List<RoomEntity>();
            var devices = new List<DeviceEntity>();
            for (int i = 0; i < roomCount; i++)
            {
                var room = new RoomEntity
                {
                    Id = Guid.NewGuid(),
                    RoomNumber = (100 + i).ToString(),
                    RoomType = i % 2 == 0 ? "Single" : "Double",
                    Status = "Available"
                };

                var device = new DeviceEntity
                {
                    Id = Guid.NewGuid(),
                    DeviceUUID = Guid.NewGuid().ToString(),
                    Room = room,
                    RoomId = room.Id
                };

                room.Device = device;

                rooms.Add(room);
                devices.Add(device);
            }
            await _context.Rooms.AddRangeAsync(rooms);
            await _context.Devices.AddRangeAsync(devices);

            // 4. Seed Bookings
            var bookings = new List<BookingEntity>();
            foreach (var user in users)
            {
                var room = _faker.PickRandom(rooms);
                var device = _faker.PickRandom(devices);
                var booking = new BookingEntity
                {
                    Id = Guid.NewGuid(),
                    User = user,
                    UserId = user.Id,
                    DeviceId = device.Id,
                    Device = device,
                    Room = room,
                    RoomId = room.Id,
                    CheckInDate = DateTime.UtcNow.AddDays(-_faker.Random.Int(1, 5)),
                    CheckOutDate = DateTime.UtcNow.AddDays(_faker.Random.Int(1, 10)),
                    Status = "Active"
                };
                bookings.Add(booking);
            }
            await _context.Bookings.AddRangeAsync(bookings);

            // 5. Seed Room Service Menu
            var menuItems = new List<RoomServiceMenuEntity>();
            for (int i = 0; i < 10; i++)
            {
                menuItems.Add(new RoomServiceMenuEntity
                {
                    ItemName = _faker.Commerce.ProductName(),
                    Description = _faker.Lorem.Sentence(),
                    Price = _faker.Random.Decimal(10, 200),
                    Available = true
                });
            }
            await _context.RoomServiceMenu.AddRangeAsync(menuItems);

            // 6. Seed Room Service Orders
            var orders = new List<RoomServiceOrderEntity>();
            var orderItems = new List<RoomServiceOrderItemEntity>();

            foreach (var booking in bookings)
            {
                if (_faker.Random.Bool())
                {
                    var order = new RoomServiceOrderEntity
                    {
                        Id = Guid.NewGuid(),
                        User = users[0],
                        UserId = users[0].Id,
                        Note = "This is a note",
                        //OrderTime = DateTime.UtcNow.AddHours(-_faker.Random.Int(1, 10)),
                        Status = "Pending",
                        Items = new List<RoomServiceOrderItemEntity>() { }
                      
                    };
                    orders.Add(order);

                    // Add 1-3 items per order
                    foreach (var menuItem in _faker.PickRandom(menuItems, _faker.Random.Int(1, 3)))
                    {
                        var orderItem = new RoomServiceOrderItemEntity
                        {
                            Id = Guid.NewGuid(),
                            Order = order,
                            OrderId = order.Id,
                            Item = menuItem,
                            ItemId = menuItem.Id,
                            Quantity = _faker.Random.Int(1, 3),
                            Price = menuItem.Price
                        };
                        order.Items.Add(orderItem);
                        orderItems.Add(orderItem);
                    }
                }
            }
            await _context.RoomServiceOrders.AddRangeAsync(orders);
            await _context.RoomServiceOrderItems.AddRangeAsync(orderItems);

            // 7. Seed Messages
            //var messages = new List<MessageEntity>();
            //foreach (var booking in bookings)
            //{
            //    for (int i = 0; i < _faker.Random.Int(1, 5); i++)
            //    {
            //        var isUser = _faker.Random.Bool();
            //        var message = new MessageEntity
            //        {
            //            Id = Guid.NewGuid(),
            //            Booking = booking,
            //            BookingId = booking.Id,
            //            SenderType = isUser ? "User" : "Staff",
            //            SenderUserId = isUser ? booking.UserId : Guid.Empty,
            //            SenderStaffId = !isUser ? _faker.PickRandom(staff).Id : null,
            //            MessageText = _faker.Lorem.Sentence()
            //        };
            //        messages.Add(message);
            //    }
            //}
            //await _context.Messages.AddRangeAsync(messages);

            // Save all changes
            await _context.SaveChangesAsync();
        }
    }
}
