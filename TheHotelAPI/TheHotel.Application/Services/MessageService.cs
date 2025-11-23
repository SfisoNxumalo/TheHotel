using Microsoft.Extensions.Logging;
using TheHotel.Application.Interfaces;
using TheHotel.Application.ServiceCustomExceptions;
using TheHotel.Domain.DTOs.MessageDTO;
using TheHotel.Domain.DTOs.NewFolder;
using TheHotel.Domain.Entities;
using TheHotel.Domain.Interfaces.Repositories;

namespace TheHotel.Application.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IRealTimeNotifier _realtimeNotifier;
        private readonly IUserService _userService;
        private readonly ILogger<MessageService> _logger;

        public MessageService(IMessageRepository messageRepository, IRealTimeNotifier realtimeNotifier, IUserService userService, ILogger<MessageService> logger)
        {
            _messageRepository = messageRepository;
            _realtimeNotifier = realtimeNotifier;
            _userService = userService;
            _logger = logger;
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

            var user = _userService.GetUserByIdAsync(message.UserId);

            if (user == null)
                throw new UserNotFoundException($"A user with id '{message.UserId}' was not found");

            var staff = _userService.GetStaffByIdAsync(message.StaffId);
            if (staff == null)
                throw new UserNotFoundException($"A user with id '{message.StaffId}' was not found");


            var newMessage = new MessageEntity
            {
                Id = Guid.NewGuid(),
                UserId = message.UserId,
                MessageText = message.MessageText,
                StaffId = message.StaffId,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
                senderId = message.SenderId
            };


            await _messageRepository.AddAsync(newMessage);

            var savedMessage = await _messageRepository.GetMessageByIdAsync(newMessage.Id);

            var receiver = message.SenderId.Equals(message.UserId) ? message.StaffId : message.UserId;

            await _realtimeNotifier.BroadcastMessage(receiver, savedMessage);

            return savedMessage;
        }
    }
}
