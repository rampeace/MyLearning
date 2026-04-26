using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice.OOP.Design
{
    public interface INotification
    {
        bool Notify(string message);
    }

    public class EmailNotification : INotification
    {
        public bool Notify(string message) => true;
    }

    public class SmsNotification : INotification
    {
        public bool Notify(string message) => true;
    }

    public class Logistics
    {
        List<INotification> _notification;

        public Logistics(List<INotification> notification)
        {
            _notification = notification;
        }

        public void DeliverItems()
        {
            // Operations to deliver items
            // is successful

            _notification.ForEach(o => o.Notify("Delivered Successfully!"));
        }
    }
}
