using TheHotel.Application.Interfaces;
using TheHotel.Domain.DTOs.NewFolder;
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

        public async Task<MessageEntity> SendMessageAsync(SendMessageDTO message)
        {

            var newMessage = new MessageEntity
            {
                SenderUserId = message.SenderUserId,
                MessageText = message.MessageText,
                SenderStaffId = message.ReceiverUserId,

            };

            await _messageRepository.AddAsync(newMessage);
            return newMessage;
        }
    }
}
