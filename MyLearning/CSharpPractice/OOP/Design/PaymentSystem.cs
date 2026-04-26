using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice.OOP.Design
{
    public interface IPayment
    {
        bool FundMoney(decimal amount);
    }

    public class BankPayment : IPayment
    {
        public bool FundMoney(decimal amount)
        {
            // Deduct money from the bank

            return true;
        }
    }

    public class UpiPayment : IPayment
    {
        public bool FundMoney(decimal amount)
        {
            // Deduct money from the bank

            return true;
        }
    }

    public class PaymentSystem
    {
        IPayment _payment;

        public PaymentSystem(IPayment payment) 
        {
            _payment = payment;
        }

        public void AddMoneyToWallet(decimal amount)
        {
            bool success = _payment.FundMoney(amount);

        }
    }

    public class PaymentFactory
    {
        private Dictionary<string, IPayment> _payments = new Dictionary<string, IPayment>();

        public void Add(string name, IPayment payment) => _payments.Add(name, payment);

        public IPayment Get(string type) => _payments[type];
    }
}
