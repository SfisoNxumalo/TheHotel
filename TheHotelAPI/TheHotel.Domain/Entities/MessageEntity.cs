using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheHotel.Domain.Entities
{
    public class MessageEntity : BaseEntity
    {
        [Required]
        public Guid UserId { get; set; }
        public Guid StaffId { get; set; }

        [Required]
        public Guid senderId { get; set; }

        [Required]
        [StringLength(1000)]
        public string MessageText { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        public UserEntity? User { get; set; }

        [ForeignKey(nameof(StaffId))]
        public StaffEntity? Staff { get; set; }
    }
}
