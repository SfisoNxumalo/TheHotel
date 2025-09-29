using System.ComponentModel.DataAnnotations;

namespace TheHotel.Domain.Entities
{
    public class MessageEntity : BaseEntity
    {
        public Guid BookingId { get; set; }
        public string SenderType { get; set; } = null!; // "User" or "Staff"

        [Required]
        public Guid SenderUserId { get; set; }
        public Guid? SenderStaffId { get; set; }

        [Required]
        public string MessageText { get; set; } = null!;

        public BookingEntity Booking { get; set; } = null!;
        public UserEntity? SenderUser { get; set; }
        public StaffEntity? SenderStaff { get; set; }
    }
}
