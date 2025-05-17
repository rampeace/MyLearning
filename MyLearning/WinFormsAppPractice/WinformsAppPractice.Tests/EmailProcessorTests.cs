using Moq;
using PracticeApp.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinformsAppPractice.Tests
{
    public class EmailProcessorTests
    {
        [Fact]
        public async Task ProcessAsync_EmailVerified_ReturnsTrue()
        {
            // Arrange
            var mockVerification = new Mock<IEmailVerificationService>();
            var mockLogger = new Mock<ILogger>();

            mockVerification.Setup(v => v.VerifyEmailAsync("test@example.com"))
                            .ReturnsAsync(true);

            var processor = new EmailProcessor(mockVerification.Object, mockLogger.Object);

            // Act
            var result = await processor.ProcessAsync("test@example.com");

            // Assert
            Assert.True(result);
            mockLogger.Verify(l => l.Log(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public async Task ProcessAsync_EmailNotVerified_LogsAndReturnsFalse()
        {
            // Arrange
            var mockVerification = new Mock<IEmailVerificationService>();
            var mockLogger = new Mock<ILogger>();

            mockVerification.Setup(v => v.VerifyEmailAsync("fail@example.com"))
                            .ReturnsAsync(false);

            var processor = new EmailProcessor(mockVerification.Object, mockLogger.Object);

            // Act
            var result = await processor.ProcessAsync("fail@example.com");

            // Assert
            Assert.False(result);
            mockLogger.Verify(l => l.Log("Email verification failed for fail@example.com"), Times.Once);
        }

        [Fact]
        public async Task ProcessAsync_ThrowsException_LogsAndReturnsFalse()
        {
            // Arrange
            var mockVerification = new Mock<IEmailVerificationService>();
            var mockLogger = new Mock<ILogger>();

            mockVerification.Setup(v => v.VerifyEmailAsync("error@example.com"))
                            .ThrowsAsync(new Exception("Service unavailable"));

            var processor = new EmailProcessor(mockVerification.Object, mockLogger.Object);

            // Act
            var result = await processor.ProcessAsync("error@example.com");

            // Assert
            Assert.False(result);
            mockLogger.Verify(l => l.Log("Error verifying email: Service unavailable"), Times.Once);
        }
    }
}
