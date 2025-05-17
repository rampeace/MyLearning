using Moq;
using PracticeApp.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace WinformsAppPractice.Tests
{
    public class UserActionServiceTests
    {
        [Fact]
        public void PerformActionTest()
        {
            // Arrange
            Mock<IActionLogger> moqLog = new Mock<IActionLogger>();
            Mock<INotifier> moqNotify = new Mock<INotifier>();
            UserActionService service = new(moqLog.Object, moqNotify.Object);

            // Act
            service.PerformAction("1", "success");

            // Assert
            moqLog.Verify(l => l.LogAction("1", "success"), Times.Once);
            moqNotify.Verify(n => n.SendNotification("1", "You performed: success"), Times.Once);
        }
    }
}
