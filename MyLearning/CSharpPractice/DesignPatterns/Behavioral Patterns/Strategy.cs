using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice.DesignPatterns
{
    // Strategy = Move behavior OUT of the class and MAKE IT PLUGGABLE
    // “Is behavior injected or decided inside?” - Behaviour Injection
    // “Can I add a new behavior WITHOUT touching the existing class?”
    // Patterns evolve with language features

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

    // Strategy pattern using delegates
    public class StrategyInLinq
    {
        public static void Filter()
        {
            int[] nums = [1, 4, 7, 1, 3, 5, 8, 6];

            nums.Where(num => num % 2 == 0); // decision made between multiple stragegies - Strategy pattern

            var result = nums.Select(x => x * 2); // No decision between multiple strategies - Not a strategy pattern
        }
    }
}
