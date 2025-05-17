using Moq;
using PracticeApp.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinformsAppPractice.Tests
{
    public class PaymentServiceTest
    {
        [Fact]
        public void MakePaymentTest()
        {
            // Arrange
            Mock<IPaymentGateway> moq = new Mock<IPaymentGateway>();
            moq.Setup(p => p.Charge(It.IsAny<string>(),  It.IsAny<decimal>())).Returns(true);
            PaymentService service = new PaymentService(moq.Object);
            /*
             * Expression: p => p.Charge("123", 100")
                → Method: Charge
                → Arguments: ["123", 100]
                → Return: true
             */

            // Act
            bool success = service.MakePayment("123", 100);

            // Assert
            Assert.True(success);
            moq.Verify(p => p.Charge("123", 100), Times.Once);
        }
    }
}
