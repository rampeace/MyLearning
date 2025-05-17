using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeApp.Core.Services
{
    public interface IUserRepository3
    {
        bool UserExists(string email);
        void ResetPassword(string email);
    }

    public interface INotifier2
    {
        void SendResetLink(string email);
    }

    public class PasswordResetService
    {
        private readonly IUserRepository3 _userRepository;
        private readonly INotifier2 _notifier;

        public PasswordResetService(IUserRepository3 userRepository, INotifier2 notifier)
        {
            _userRepository = userRepository;
            _notifier = notifier;
        }

        public bool ResetPassword(string email)
        {
            if (!_userRepository.UserExists(email))
                return false;

            _userRepository.ResetPassword(email);
            _notifier.SendResetLink(email);
            return true;
        }
    }

}
