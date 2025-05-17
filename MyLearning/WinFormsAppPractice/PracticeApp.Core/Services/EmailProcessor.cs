using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeApp.Core.Services
{
    public interface IEmailVerificationService
    {
        Task<bool> VerifyEmailAsync(string email);
    }

    public interface ILogger
    {
        void Log(string message);
    }

    public class EmailProcessor
    {
        private readonly IEmailVerificationService _verificationService;
        private readonly ILogger _logger;

        public EmailProcessor(IEmailVerificationService verificationService, ILogger logger)
        {
            _verificationService = verificationService;
            _logger = logger;
        }

        public async Task<bool> ProcessAsync(string email)
        {
            try
            {
                bool isVerified = await _verificationService.VerifyEmailAsync(email);
                if (!isVerified)
                {
                    _logger.Log($"Email verification failed for {email}");
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                _logger.Log($"Error verifying email: {ex.Message}");
                return false;
            }
        }
    }
}
