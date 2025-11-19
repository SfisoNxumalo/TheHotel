using System.ComponentModel.DataAnnotations;

namespace TheHotel.Domain.DTOs.NewFolder
{
    public class SendMessageDTO
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public Guid SenderId { get; set; }

        [Required]
        public string MessageText { get; set; } = null!;

        [Required]
        public Guid StaffId { get; set; }
    }
}
