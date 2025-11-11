using System.ComponentModel.DataAnnotations;

namespace TheHotel.Domain.Entities
{
    public class MessageEntity : BaseEntity
    {

        [Required]
        public Guid SenderUserId { get; set; }
        public Guid? SenderStaffId { get; set; }

        [Required]
        public string MessageText { get; set; } = null!;

        public UserEntity? SenderUser { get; set; }
        public StaffEntity? SenderStaff { get; set; }
    }
}
