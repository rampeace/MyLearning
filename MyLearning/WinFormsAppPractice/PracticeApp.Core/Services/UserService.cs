using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeApp.Core
{
    public interface IUserRepository
    {
        string GetUserById(int id);
        void PrintHello();
    }

    public class UserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public string GetUserName(int id) => _repository.GetUserById(id);

        public void Print()
        {
            _repository.PrintHello();
        }
    }
}
