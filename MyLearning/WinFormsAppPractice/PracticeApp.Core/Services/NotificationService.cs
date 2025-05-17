using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeApp.Core.Services
{
    public interface IEmailService
    {
        void SendEmail(string to, string subject, string body);
    }

    public interface IUserRepository2
    {
        string GetUserEmail(int userId);
    }

    public class NotificationService
    {
        private readonly IUserRepository2 _userRepo;
        private readonly IEmailService _emailService;

        public NotificationService(IUserRepository2 userRepo, IEmailService emailService)
        {
            _userRepo = userRepo;
            _emailService = emailService;
        }

        public void NotifyUser(int userId, string message)
        {
            string email = _userRepo.GetUserEmail(userId);
            string subject = "Notification";
            _emailService.SendEmail(email, subject, message);
        }
    }
}
