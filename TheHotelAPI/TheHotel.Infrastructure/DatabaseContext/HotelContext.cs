using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TheHotel.Domain.Entities;

namespace TheHotel.Infrastructure.DatabaseContext
{
    public class HotelContext : DbContext
    {
        public HotelContext(DbContextOptions<HotelContext> options) : base(options) { }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<RoomEntity> Rooms { get; set; }
        public DbSet<DeviceEntity> Devices { get; set; }
        public DbSet<BookingEntity> Bookings { get; set; }
        public DbSet<RoomServiceMenuEntity> RoomServiceMenu { get; set; }
        public DbSet<RoomServiceOrderEntity> RoomServiceOrders { get; set; }
        public DbSet<RoomServiceOrderItemEntity> RoomServiceOrderItems { get; set; }
        public DbSet<StaffEntity> Staff { get; set; }
        public DbSet<MessageEntity> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Unique RoomNumber
            modelBuilder.Entity<RoomEntity>()
                .HasIndex(r => r.RoomNumber)
                .IsUnique();

            // Unique Device per Room
            modelBuilder.Entity<DeviceEntity>()
                .HasIndex(d => d.RoomId)
                .IsUnique();

            // Relationships for Message
            modelBuilder.Entity<MessageEntity>()
                .HasOne(m => m.SenderUser)
                .WithMany(u => u.Messages)
                .HasForeignKey(m => m.SenderUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MessageEntity>()
                .HasOne(m => m.SenderStaff)
                .WithMany(s => s.Messages)
                .HasForeignKey(m => m.SenderStaffId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
