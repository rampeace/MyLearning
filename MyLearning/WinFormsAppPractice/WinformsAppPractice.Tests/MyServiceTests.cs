using Moq;
using PracticeApp.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinformsAppPractice.Tests
{
    public class MyServiceTests
    {
        [Fact]
        public void DoWork_ShouldLogCorrectMessage()
        {
            // Arrange
            var mockLogger = new Mock<ILogger2>();
            string capturedMessage = string.Empty;

            // Test what arguments a method was called with
            mockLogger
                .Setup(l => l.Log(It.IsAny<string>()))
                .Callback<string>(msg => capturedMessage = msg);

            var service = new MyService(mockLogger.Object);

            // Act
            service.DoWork();

            // Assert
            Assert.Equal("Working hard!", capturedMessage); // 👈 captured from Callback
            mockLogger.Verify(l => l.Log("Working hard!"), Times.Once);
        }
    }
}
