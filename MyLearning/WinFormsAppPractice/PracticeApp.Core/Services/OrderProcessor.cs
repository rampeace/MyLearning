using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeApp.Core.Services
{
    public interface IInventoryService
    {
        bool IsInStock(string productId, int quantity);
        void ReduceStock(string productId, int quantity);
    }

    public interface IPaymentService
    {
        bool ProcessPayment(string userId, decimal amount);
    }

    public interface INotificationService
    {
        void NotifyUser(string userId, string message);
    }

    public class OrderProcessor
    {
        private readonly IInventoryService _inventory;
        private readonly IPaymentService _payment;
        private readonly INotificationService _notification;

        public OrderProcessor(IInventoryService inventory, IPaymentService payment, INotificationService notification)
        {
            _inventory = inventory;
            _payment = payment;
            _notification = notification;
        }

        public bool ProcessOrder(string userId, string productId, int quantity, decimal pricePerUnit)
        {
            if (!_inventory.IsInStock(productId, quantity))
            {
                _notification.NotifyUser(userId, "Product is out of stock.");
                return false;
            }

            decimal totalPrice = quantity * pricePerUnit;

            if (!_payment.ProcessPayment(userId, totalPrice))
            {
                _notification.NotifyUser(userId, "Payment failed.");
                return false;
            }

            _inventory.ReduceStock(productId, quantity);
            _notification.NotifyUser(userId, "Order processed successfully.");
            return true;
        }
    }
}
