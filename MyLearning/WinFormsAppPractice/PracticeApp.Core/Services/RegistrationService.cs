using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeApp.Core.Services
{
    public interface IUserRepository
    {
        void AddUser(string username, string password);
    }

    public interface IEmailSender
    {
        void SendEmail(string to, string subject, string body);
    }

    public class RegistrationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailSender _emailSender;

        public RegistrationService(IUserRepository userRepository, IEmailSender emailSender)
        {
            _userRepository = userRepository;
            _emailSender = emailSender;
        }

        public void Register(string username, string password, string email)
        {
            _userRepository.AddUser(username, password);
            _emailSender.SendEmail(email, "Welcome", $"Hello {username}, welcome to our system!");
        }
    }
}
