using Moq;
using Newtonsoft.Json.Linq;
using PracticeApp.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinformsAppPractice.Tests
{
    public class NotificationServiceTests
    {
        [Fact]
        public void NotifyUserTest()
        {
            // Arrange
            // Create objects
            // Mock dependencies
            // Set input values
            Mock<IEmailService> moqEmail = new Mock<IEmailService>();
            Mock<IUserRepository2> moqRepo = new Mock<IUserRepository2>();

            moqRepo.Setup(r => r.GetUserEmail(1)).Returns("ram@example.com");            

            NotificationService service = new NotificationService(moqRepo.Object, moqEmail.Object);

            // Act
            // Call the method you're testing. This is the real action.
            service.NotifyUser(1, "Welcome");

            // Assert
            // Verify that the outcome is what you expected.
            moqEmail.Verify(e => e.SendEmail("ram@example.com", "Notification", "Welcome"), Times.Once);
        }
    }
}
