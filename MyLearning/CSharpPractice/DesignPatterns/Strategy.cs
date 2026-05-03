using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice.DesignPatterns
{
    // Strategy = Move behavior OUT of the class and MAKE IT PLUGGABLE
    // “Is behavior injected or decided inside?” - Behaviour Injection
    // “Can I add a new behavior WITHOUT touching the existing class?”
    public interface ICustomerType
    {
        double GetDiscount();
    }

    public class GoldCustomer : ICustomerType
    {
        public double GetDiscount()
        {
            return 0.3;
        }
    }

    public class SilverCustomer : ICustomerType
    {
        public double GetDiscount()
        {
            return 0.2;
        }
    }

    public class Customer(ICustomerType customerType)
    {
        private ICustomerType _customerType = customerType;

        public double GetDiscount() => _customerType.GetDiscount();

        /*
         * The real value appears when behavior becomes complex or frequently changing. Otherwise, it may be over-engineering.”
         * Behaviour can change at run time
         *  var customer = new Customer(new SilverCustomer());

            Console.WriteLine(customer.GetDiscount()); // 0.2

            customer.SetCustomerType(new GoldCustomer());

            Console.WriteLine(customer.GetDiscount()); // 0.3
         */

        public void SetCustomerType(ICustomerType customerType) => _customerType = customerType;
    }
}
