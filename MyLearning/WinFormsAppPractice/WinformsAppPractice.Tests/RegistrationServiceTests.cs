using Moq;
using PracticeApp.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinformsAppPractice.Tests
{
    public class RegistrationServiceTests
    {
        [Fact]
        public void RegisterTest()
        {
            // Arrange
            Mock<IUserRepository> mockRepo = new();
            Mock<IEmailSender> mockEmail = new();
            RegistrationService registrationService = new(mockRepo.Object, mockEmail.Object);

            // Act
            registrationService.Register("ram", "123", "example@example.com");

            // Assert
            mockRepo.Verify(r => r.AddUser("ram", "123"), Times.Once);
            mockEmail.Verify(e => e.SendEmail("example@example.com", It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }
    }
}
