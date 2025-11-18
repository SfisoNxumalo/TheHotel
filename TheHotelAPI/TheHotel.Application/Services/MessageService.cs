using TheHotel.Application.Interfaces;
using TheHotel.Domain.DTOs.MessageDTO;
using TheHotel.Domain.DTOs.NewFolder;
using TheHotel.Domain.Entities;
using TheHotel.Domain.Interfaces;

namespace TheHotel.Application.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IRealTimeNotifier _realtimeNotifier;

        public MessageService(IMessageRepository messageRepository, IRealTimeNotifier realtimeNotifier)
        {
            _messageRepository = messageRepository;
            _realtimeNotifier = realtimeNotifier;
        }

        public async Task<IEnumerable<FetchMessageDTO>> GetMessagesByUserIdAsync(Guid userId)
        {
            return await _messageRepository.GetMessagesByUserIdAsync(userId);
        }

        public async Task<IEnumerable<MessageEntity>> GetMessagesForBookingAsync(Guid bookingId)
        {
            return await _messageRepository.GetMessagesByBookingIdAsync(bookingId);
        }

        public async Task<FetchMessageDTO> SendMessageAsync(SendMessageDTO message)
        {
            var newMessage = new MessageEntity
            {
                Id = Guid.NewGuid(),
                UserId = message.UserId,
                MessageText = message.MessageText,
                StaffId = message.StaffId,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
            };



            await _messageRepository.AddAsync(newMessage);

            var savedMessage = await _messageRepository.GetMessageByIdAsync(newMessage.Id);

            await _realtimeNotifier.BroadcastMessage(message.UserId, savedMessage);

            return savedMessage;
        }
    }
}
