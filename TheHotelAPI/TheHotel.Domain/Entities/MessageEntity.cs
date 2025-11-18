using System.ComponentModel.DataAnnotations;

namespace TheHotel.Domain.Entities
{
    public class MessageEntity : BaseEntity
    {
        [Required]
        public Guid UserId { get; set; }
        public Guid StaffId { get; set; }

        public Guid senderId { get; set; }

        [Required]
        public string MessageText { get; set; } = null!;

        public UserEntity? User { get; set; }
        public StaffEntity? Staff { get; set; }
    }
}
