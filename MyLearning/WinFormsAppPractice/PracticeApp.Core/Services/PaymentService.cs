using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeApp.Core.Services
{
    public interface IPaymentGateway
    {
        bool Charge(string cardNumber, decimal amount);
    }

    public class PaymentService
    {
        private readonly IPaymentGateway _gateway;

        public PaymentService(IPaymentGateway gateway)
        {
            _gateway = gateway;
        }

        public bool MakePayment(string cardNumber, decimal amount)
        {
            return _gateway.Charge(cardNumber, amount);
        }
    }
}
