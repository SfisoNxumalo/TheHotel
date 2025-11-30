using AutoFixture;
using Microsoft.Extensions.Logging;
using Moq;
using TheHotel.Application.Interfaces;
using TheHotel.Application.Services;
using TheHotel.Domain.Interfaces.Repositories;

namespace TheHotel.Application.UnitTests.MessageServiceTests.BaseSetup
{
    public abstract class TestBase_MessageService
    {
        protected Fixture Fixture;

        protected Mock<IMessageRepository> MessageRepositoryMock;
        protected Mock<IRealTimeNotifier> RealTimeNotifierMock;
        protected Mock<IUserService> UserServiceMock;
        protected Mock<ILogger<MessageService>> LoggerMock;

        protected MessageService MessageService;

        [SetUp]
        public void BaseSetup()
        {
            
            Fixture = new Fixture();

            Fixture.Behaviors
            .OfType<ThrowingRecursionBehavior>()
            .ToList()
            .ForEach(b => Fixture.Behaviors.Remove(b));

            Fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            MessageRepositoryMock = new Mock<IMessageRepository>();
            RealTimeNotifierMock = new Mock<IRealTimeNotifier>();
            UserServiceMock = new Mock<IUserService>();
            LoggerMock = new Mock<ILogger<MessageService>>();

            MessageService = new MessageService(
                MessageRepositoryMock.Object,
                RealTimeNotifierMock.Object,
                UserServiceMock.Object,
                LoggerMock.Object
            );
        }
    }
}
