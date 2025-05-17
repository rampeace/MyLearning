using Moq;
using PracticeApp.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinformsAppPractice.Tests
{
    public class LoginServiceTest
    {
        [Fact]
        public void LoginTest()
        {
            // Arrange
            Mock<ILoginLogger> mockLogger = new();
            Mock<IAdminNotifier> mockAdminNotifier = new();
            LoginService service = new(mockLogger.Object, mockAdminNotifier.Object);

            // Act
            bool success = service.Login("test", "2323");

            // Assert
            Assert.False(success);
            mockLogger.Verify(l => l.Log("test", false), Times.Once);
            mockAdminNotifier.Verify(n => n.Notify(It.IsAny<string>()), Times.Never);
        }
    }
}
