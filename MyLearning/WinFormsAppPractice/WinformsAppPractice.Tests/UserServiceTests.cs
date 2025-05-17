using Moq;
using PracticeApp.Core;
using System.Linq.Expressions;

namespace WinformsAppPractice.Tests
{

    public class UserServiceTests
    {
        /*
         * LINQ has two flavors:
         * 1. LINQ to Objects
         * 2. LINQ to Entities / LINQ to SQL / LINQ to Anything-Else
         * var result = db.Users.Where(x => x.Age > 30);
         * Here x => x.Age > 30 is compiled to an expression tree
         * SELECT * FROM Users WHERE Age > 30
         * */
        [Fact]
        public void GetUserName_ReturnsMockedValue()
        {
            // Moq uses expression trees to analyze what method/property you're trying to set up or verify.
            // Think of it like a blueprint of code — you can inspect or modify it, but it doesn’t run by itself.

            var mocRepo = new Mock<IUserRepository>();
            mocRepo.Setup(r => r.GetUserById(1)).Returns("Ram");
            mocRepo.Setup(r => r.PrintHello());

            UserService userService = new UserService(mocRepo.Object);
            string userName = userService.GetUserName(1);
            userService.Print();

            mocRepo.Verify(r => r.PrintHello(), Times.Exactly(1));

            Assert.Equal("Ram", userName);
        }
    }
}