using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeApp.Core.Services
{
    public interface IActionLogger
    {
        void LogAction(string userId, string action);
    }

    public interface INotifier
    {
        void SendNotification(string userId, string message);
    }

    public class UserActionService
    {
        private readonly IActionLogger _logger;
        private readonly INotifier _notifier;

        public UserActionService(IActionLogger logger, INotifier notifier)
        {
            _logger = logger;
            _notifier = notifier;
        }

        public void PerformAction(string userId, string action)
        {
            _logger.LogAction(userId, action);
            _notifier.SendNotification(userId, $"You performed: {action}");
        }
    }
}
