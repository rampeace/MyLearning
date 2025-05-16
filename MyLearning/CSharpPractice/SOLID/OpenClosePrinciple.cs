using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice.SOLID
{
    internal class OpenClosePrinciple
    {
        public abstract class NotificationSender
        {
            public abstract void SendMessage();
        }

        public class SmsSender : NotificationSender
        {
            public override void SendMessage()
            {
                Console.WriteLine("SMS sent");
            }
        }

        public class EmailSender : NotificationSender
        {
            public override void SendMessage()
            {
                Console.WriteLine("Email sent");
            }
        }

        public void SendMessage(NotificationSender sender)
        {
            sender.SendMessage();
        }
    }
}
