using Moq;
using PracticeApp.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinformsAppPractice.Tests
{
    public class ReportServiceTest
    {
        [Fact]
        public void GenerateReportTest()
        {
            // Arrange
            Mock<IDataFetcher> moqData = new();
            Mock<INotificationSender> mockNotification = new();
            moqData.Setup(d => d.FetchData(1)).Returns("data");
            ReportService reportService = new(moqData.Object, mockNotification.Object);

            // Act
            string report = reportService.GenerateReport(1, "2");

            // Assert
            Assert.False(string.IsNullOrEmpty(report));
            moqData.Verify(d => d.FetchData(1), Times.Once);
            mockNotification.Verify(n => n.SendNotification("2", "Report generated successfully."), Times.Once);

        }

        [Fact]
        public void GenerateReport_NoData_SendsNotFoundNotification()
        {
            // Arrange
            Mock<IDataFetcher> moqData = new();
            Mock<INotificationSender> mockNotification = new();
            moqData.Setup(d => d.FetchData(1)).Returns(string.Empty); // or null if your implementation allows
            ReportService reportService = new(moqData.Object, mockNotification.Object);

            // Act
            string report = reportService.GenerateReport(1, "2");

            // Assert
            Assert.Null(report);
            moqData.Verify(d => d.FetchData(1), Times.Once);
            mockNotification.Verify(n => n.SendNotification("2", "Report data not found."), Times.Once);
        }
    }
}
