using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheHotel.Domain.DTOs.NewFolder;
using TheHotel.Domain.Entities;

namespace TheHotel.Application.Interfaces
{
    public interface IMessageService
    {
        Task<IEnumerable<MessageEntity>> GetMessagesForBookingAsync(Guid bookingId);
        Task<MessageEntity> SendMessageAsync(SendMessageDTO message);
    }
}
