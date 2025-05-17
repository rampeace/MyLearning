using Moq;
using PracticeApp.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinformsAppPractice.Tests
{
    public class OrderProcessorTests
    {
        [Fact]
        public void ProcessOrderTest()
        {
            // Arrange
            Mock<IInventoryService> mockInventory = new Mock<IInventoryService>();
            Mock<IPaymentService> mockPayment = new Mock<IPaymentService>();
            Mock<INotificationService> mockNotification = new Mock<INotificationService>();
            mockInventory.Setup(i => i.IsInStock("2", 5)).Returns(true);
            mockPayment.Setup(p => p.ProcessPayment("1", 500)).Returns(true);

            OrderProcessor orderProcessor = new OrderProcessor(mockInventory.Object, mockPayment.Object, mockNotification.Object);

            // Act
            bool success = orderProcessor.ProcessOrder("1", "2", 5, 100);

            // Assert
            Assert.True(success);
            mockInventory.Verify(i => i.IsInStock("2", 5), Times.Once);
            mockPayment.Verify(p => p.ProcessPayment("1", 500), Times.Once);
            mockInventory.Verify(i => i.ReduceStock("2", 5), Times.Once);
            mockNotification.Verify(n => n.NotifyUser("1", "Order processed successfully."));
        }
    }
}
