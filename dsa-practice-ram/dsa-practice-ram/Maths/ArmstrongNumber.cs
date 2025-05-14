namespace dsa_practice_ram.Maths
{
    internal class ArmstrongNumber
    {
        /*  
         *  153 is an Armstrong number because:  
            1^3 + 5^3 + 3^3 = 153

            9474 is an Armstrong number because:  
            9^4 + 4^4 + 7^4 + 4^4 = 9474  
         */

        public void CheckArmstrongNumber(int number)
        {
            int originalNumber = number;
            int sum = 0;
            int digits = number.ToString().Length;

            while (number > 0)
            {
                int digit = number % 10;
                sum += (int)Math.Pow(digit, digits);
                number /= 10;
            }

            if (sum == originalNumber)
                Console.WriteLine($"{originalNumber} is an Armstrong number.");
            else
                Console.WriteLine($"{originalNumber} is not an Armstrong number.");
        }
    }
}
