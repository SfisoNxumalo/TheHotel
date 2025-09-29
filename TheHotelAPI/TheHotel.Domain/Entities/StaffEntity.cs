using System.ComponentModel.DataAnnotations;

namespace TheHotel.Domain.Entities
{
    public class StaffEntity : BaseEntity
    {
        [Required]
        public string FullName { get; set; } = null!;

        [Required]
        public string Role { get; set; } = "Receptionist";

        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
      
        public ICollection<MessageEntity> Messages { get; set; } = new List<MessageEntity>();
    }
}
