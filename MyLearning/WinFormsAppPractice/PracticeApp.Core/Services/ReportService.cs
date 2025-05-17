using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeApp.Core.Services
{
    public interface IDataFetcher
    {
        string FetchData(int reportId);
    }

    public interface INotificationSender
    {
        void SendNotification(string userId, string message);
    }

    public class ReportService
    {
        private readonly IDataFetcher _dataFetcher;
        private readonly INotificationSender _notificationSender;

        public ReportService(IDataFetcher dataFetcher, INotificationSender notificationSender)
        {
            _dataFetcher = dataFetcher;
            _notificationSender = notificationSender;
        }

        public string GenerateReport(int reportId, string userId)
        {
            var data = _dataFetcher.FetchData(reportId);
            if (string.IsNullOrEmpty(data))
            {
                _notificationSender.SendNotification(userId, "Report data not found.");
                return null;
            }
            // Imagine generating report here, returning summary string
            string reportSummary = $"Report {reportId}: {data.Substring(0, Math.Min(20, data.Length))}...";
            _notificationSender.SendNotification(userId, "Report generated successfully.");
            return reportSummary;
        }
    }
}
