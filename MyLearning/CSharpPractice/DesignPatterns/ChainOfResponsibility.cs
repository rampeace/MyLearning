using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice.DesignPatterns
{
   // The chain itself is dynamic. The pipeline can change at runtime. To support that flexibility, every node must expose a common operation.
   // Example 1: 
    public class RegistrationRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public interface IHandler
    {
        void SetNext(IHandler next);

        void Handle(RegistrationRequest request);
    }

    public abstract class HandlerBase : IHandler
    {
        protected IHandler _next;

        public void SetNext(IHandler next)
        {
            _next = next;
        }

        public virtual void Handle(RegistrationRequest request)
        {
            _next?.Handle(request);
        }
    }

    public class NullCheckHandler : HandlerBase
    {
        public override void Handle(RegistrationRequest request)
        {
            Console.WriteLine("NullCheckHandler running...");

            if (string.IsNullOrWhiteSpace(request.Username) ||
                string.IsNullOrWhiteSpace(request.Password))
            {
                Console.WriteLine("Validation failed: Username/Password cannot be empty.");
                return;
            }

            base.Handle(request);
        }
    }

    public class LengthCheckHandler : HandlerBase
    {
        public override void Handle(RegistrationRequest request)
        {
            Console.WriteLine("LengthCheckHandler running...");

            if (request.Username.Length < 5)
            {
                Console.WriteLine("Validation failed: Username too short.");
                return;
            }

            base.Handle(request);
        }
    }

    public class PasswordStrengthHandler : HandlerBase
    {
        public override void Handle(RegistrationRequest request)
        {
            Console.WriteLine("PasswordStrengthHandler running...");

            if (request.Password.Length < 8)
            {
                Console.WriteLine("Validation failed: Weak password.");
                return;
            }

            Console.WriteLine("All validations passed.");
        }
    }
    
   // Example 2:
    public abstract class SupportHandler
    {
        protected SupportHandler? _next;

        public void SetNext(SupportHandler next)
        {
            _next = next;
        }

        public abstract void Handle(string issue);
    }

    public class Level1Support : SupportHandler
    {
        public override void Handle(string issue)
        {
            if (issue == "Password Reset")
            {
                Console.WriteLine("Level 1 handled password reset.");
            }
            else
            {
                Console.WriteLine("Level 1 escalated issue.");
                _next?.Handle(issue);
            }
        }
    }

    public class Level2Support : SupportHandler
    {
        public override void Handle(string issue)
        {
            if (issue == "Software Install")
            {
                Console.WriteLine("Level 2 handled software installation.");
            }
            else
            {
                Console.WriteLine("Level 2 escalated issue.");
                _next?.Handle(issue);
            }
        }
    }

    public class Manager : SupportHandler
    {
        public override void Handle(string issue)
        {
            Console.WriteLine($"Manager handled critical issue: {issue}");
        }
    }

    public class ChainOfResponsibilityTest
    {
        public static void Test()
        {
            var level1 = new Level1Support();
            var level2 = new Level2Support();
            var manager = new Manager();

            level1.SetNext(level2);
            level2.SetNext(manager);

            level1.Handle("Password Reset");

            Console.WriteLine();

            level1.Handle("Software Install");

            Console.WriteLine();

            level1.Handle("Server Down");
        }
    }
}
