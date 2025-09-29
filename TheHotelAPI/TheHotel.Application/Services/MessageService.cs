using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheHotel.Application.Interfaces;
using TheHotel.Domain.Entities;
using TheHotel.Domain.Interfaces;

namespace TheHotel.Application.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;

        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task<IEnumerable<MessageEntity>> GetMessagesForBookingAsync(Guid bookingId)
        {
            return await _messageRepository.GetMessagesByBookingIdAsync(bookingId);
        }

        public async Task<MessageEntity> SendMessageAsync(MessageEntity message)
        {
            await _messageRepository.AddAsync(message);
            return message;
        }
    }
}
