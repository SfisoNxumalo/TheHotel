using AutoFixture;
using Moq;
using TheHotel.Application.ServiceCustomExceptions;
using TheHotel.Application.Services;
using TheHotel.Application.UnitTests.MessageServiceTests.BaseSetup;
using TheHotel.Domain.DTOs.MessageDTO;
using TheHotel.Domain.DTOs.NewFolder;
using TheHotel.Domain.Entities;

namespace TheHotel.Application.UnitTests.MessageServiceTests
{

    [TestFixture]
    public class MessageServiceTests : TestBase_MessageService
    {

        [Test]
        public async Task GetMessagesByUserIdAsync_ShouldReturnMessages()
        {
            var userId = Guid.NewGuid();
            var messages = Fixture.CreateMany<FetchMessageDTO>(3);

            MessageRepositoryMock
                .Setup(r => r.GetMessagesByUserIdAsync(userId))
                .ReturnsAsync(messages);

            var result = await MessageService.GetMessagesByUserIdAsync(userId);

            Assert.That(result, Is.EqualTo(messages));
        }

        [Test]
        public void SendMessageAsync_ShouldThrow_WhenUserNotFound()
        {
            var dto = Fixture.Create<SendMessageDTO>();

            UserServiceMock
                .Setup(s => s.GetUserByIdAsync(dto.UserId))
                .ReturnsAsync((UserEntity)null);

            Assert.ThrowsAsync<UserNotFoundException>(async () => await MessageService.SendMessageAsync(dto));
        }

        
        [Test]
        public void SendMessageAsync_ShouldThrow_WhenStaffNotFound()
        {
            var dto = Fixture.Create<SendMessageDTO>();

            UserServiceMock
                .Setup(s => s.GetUserByIdAsync(dto.UserId))
                .ReturnsAsync(Fixture.Create<UserEntity>());

            UserServiceMock
                .Setup(s => s.GetStaffByIdAsync(dto.StaffId))
                .ReturnsAsync((StaffEntity)null);

            Assert.ThrowsAsync<UserNotFoundException>(async () => await MessageService.SendMessageAsync(dto));
        }

        [Test]
        public async Task SendMessageAsync_ShouldSaveAndBroadcast()
        {
            var dto = Fixture.Create<SendMessageDTO>();
            var savedDto = Fixture.Create<FetchMessageDTO>();

            UserServiceMock
                .Setup(s => s.GetUserByIdAsync(dto.UserId))
                .ReturnsAsync(Fixture.Create<UserEntity>());

            UserServiceMock
                .Setup(s => s.GetStaffByIdAsync(dto.StaffId))
                .ReturnsAsync(Fixture.Create<StaffEntity>());

            MessageRepositoryMock
                .Setup(r => r.AddAsync(It.IsAny<MessageEntity>()))
                .Returns(Task.CompletedTask);

            MessageRepositoryMock
                .Setup(r => r.GetMessageByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync(savedDto);

            var result = await MessageService.SendMessageAsync(dto);

            Assert.That(result, Is.EqualTo(savedDto));

            var expectedReceiver =
                dto.SenderId == dto.UserId ? dto.StaffId : dto.UserId;

            RealTimeNotifierMock.Verify(
                n => n.BroadcastMessage(expectedReceiver, savedDto),
                Times.Once
            );

            MessageRepositoryMock.Verify(
                r => r.AddAsync(It.IsAny<MessageEntity>()),
                Times.Once
            );
        }
    }
}
