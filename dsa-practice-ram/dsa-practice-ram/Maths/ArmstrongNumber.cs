using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dsa_practice_ram.Maths
{
    internal class ArmstrongNumber
    {
        /*  
         *  153 is an Armstrong number because:  
            13+53+33=15313+53+33=153  

            9474 is an Armstrong number because:  
            94+44+74+44=947494+44+74+44=9474  
         */

        public void CheckArmstrongNumber(int number)
        {
            int originalNumber = number;
            int sum = 0;
            int digits = number.ToString().Length;

            while (number > 0)
            {
                int digit = number % 10;
                sum += (int)System.Math.Pow(digit, digits); // Fully qualify Math.Pow to resolve ambiguity  
                number /= 10;
            }

            if (sum == originalNumber)
                Console.WriteLine($"{originalNumber} is an Armstrong number.");
            else
                Console.WriteLine($"{originalNumber} is not an Armstrong number.");
        }
    }
}
