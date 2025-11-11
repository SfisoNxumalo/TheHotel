using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheHotel.Domain.Entities;

namespace TheHotel.Domain.DTOs.NewFolder
{
    public class SendMessageDTO
    {
        [Required]
        public Guid SenderUserId { get; set; }

        [Required]
        public string MessageText { get; set; } = null!;

        [Required]
        public Guid ReceiverUserId { get; set; }
    }
}
