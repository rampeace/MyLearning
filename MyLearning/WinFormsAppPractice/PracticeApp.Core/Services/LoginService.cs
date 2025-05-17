using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeApp.Core.Services
{
    public interface ILoginLogger
    {
        void Log(string username, bool success);
    }

    public interface IAdminNotifier
    {
        void Notify(string message);
    }

    public class LoginService
    {
        private readonly ILoginLogger _logger;
        private readonly IAdminNotifier _notifier;

        public LoginService(ILoginLogger logger, IAdminNotifier notifier)
        {
            _logger = logger;
            _notifier = notifier;
        }

        public bool Login(string username, string password)
        {
            bool isAuthenticated = (username == "admin" && password == "1234");

            _logger.Log(username, isAuthenticated);

            if (isAuthenticated)
            {
                _notifier.Notify($"User {username} logged in.");
            }

            return isAuthenticated;
        }
    }
}
