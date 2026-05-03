using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice.DesignPatterns
{
    public interface INotifier
    {
        void Send(string message);
    }

    public class EmailNotifier : INotifier
    {
        public void Send(string message)
        {
            Console.WriteLine($"Email: {message}");
        }
    }

    public abstract class NotifierDecorator : INotifier
    {
        protected readonly INotifier _inner;

        protected NotifierDecorator(INotifier inner)
        {
            _inner = inner;
        }

        public virtual void Send(string message)
        {
            _inner.Send(message);
        }
    }
    public class EncryptionDecorator : NotifierDecorator
    {
        public EncryptionDecorator(INotifier inner) : base(inner) { }

        public override void Send(string message)
        {
            var encrypted = $"[Encrypted:{message}]";
            Console.WriteLine("🔐 Encrypting message...");
            base.Send(encrypted);
        }
    }

    public class LoggingDecorator : NotifierDecorator
    {
        public LoggingDecorator(INotifier inner) : base(inner) { }

        public override void Send(string message)
        {
            Console.WriteLine("🧾 Logging: Before send");
            base.Send(message);
            Console.WriteLine("🧾 Logging: After send");
        }
    }

    public class RetryDecorator : NotifierDecorator
    {
        public RetryDecorator(INotifier inner) : base(inner) { }

        public override void Send(string message)
        {
            int attempts = 3;

            for (int i = 1; i <= attempts; i++)
            {
                try
                {
                    Console.WriteLine($"🔁 Attempt {i}");
                    base.Send(message);

                    // Simulate success
                    if (i == 1) throw new Exception("Simulated failure");

                    Console.WriteLine("✅ Success");
                    break;
                }
                catch
                {
                    Console.WriteLine("❌ Failed");
                    if (i == attempts)
                        Console.WriteLine("🚫 Giving up after retries");
                }
            }
        }
    }
    public class TestDecorator
    {
        public static void Run()
        {
            INotifier notifier =
                new RetryDecorator(
                    new LoggingDecorator(
                        new EncryptionDecorator(
                            new EmailNotifier())));

            notifier.Send("Hello World");
        }
    }
}
