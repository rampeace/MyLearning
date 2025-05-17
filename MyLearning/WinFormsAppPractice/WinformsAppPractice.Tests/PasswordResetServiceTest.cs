using Moq;
using PracticeApp.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinformsAppPractice.Tests
{
    public class PasswordResetServiceTest
    {
        [Fact]
        public void ResetPasswordTest()
        {
            // Arrange
            Mock<IUserRepository3> mockUser = new();
            Mock<INotifier2> mockNotifier = new();
            mockUser.Setup(u => u.UserExists("ram@example.com")).Returns(true);
            PasswordResetService service = new(mockUser.Object, mockNotifier.Object);

            // Act
            bool success = service.ResetPassword("ram@example.com");

            // Assert
            Assert.True(success);
            mockUser.Verify(u => u.ResetPassword("ram@example.com"), Times.Once);
            mockNotifier.Verify(n => n.SendResetLink("ram@example.com"), Times.Once);
        }
    }
}
