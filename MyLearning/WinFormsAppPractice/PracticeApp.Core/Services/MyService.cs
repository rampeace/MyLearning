using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeApp.Core.Services
{
    public interface ILogger2
    {
        void Log(string message);
    }

    public class MyService
    {
        private readonly ILogger2 _logger;

        public MyService(ILogger2 logger)
        {
            _logger = logger;
        }

        public void DoWork()
        {
            _logger.Log("Working hard!");
        }
    }

}
