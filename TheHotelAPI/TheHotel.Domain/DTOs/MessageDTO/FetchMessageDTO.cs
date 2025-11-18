using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHotel.Domain.DTOs.MessageDTO
{
    public class FetchMessageDTO
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid senderId { get; set; }

        public string MessageText { get; set; }

        public Guid StaffId { get; set; }

        public DateTime CreatedDate { get; set; }

    }
}
