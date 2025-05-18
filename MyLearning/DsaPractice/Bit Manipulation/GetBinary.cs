using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsaPractice.Bit_Manipulation
{
    internal class GetBinary
    {
        /*
         * Manual conversion:
         * i = 13
         * 
         * 13 / 2 => Quotient = 6, Reminder = 1
         * 6 / 2 => Quotient => 3, Reminder = 0
         * 3 / 2 => Quotient => 1, Reminder = 1
         * 1 / 2 => Quotient => 0 (Actually 0.5, but it's rounded to 0), Reminder: 1
         * 1101
         * 
         * i = -13         * 
         * 
         */

        public void GetBinaryDigits()
        {
            int i = 5;
            string binary = Convert.ToString(i, 2);
        }

        public void GetBinaryManual()
        {
            int i = 13;

            LinkedList<char> result = new();

            while (i > 0)
            {
                result.AddFirst((char)('0' + i % 2));
                i /= 2;
            }
            Console.WriteLine(new string(result.ToArray()));
        }
    }
}
