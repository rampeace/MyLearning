namespace DsaPractice.Maths
{
    internal class PowerOfTwo
    {
        // This is the bruteforce solution to check if a number is power of two
        /*
         * 2^1 -> 2
         * 2^2 -> 4
         * 2^3 -> 8         
         * 
         * */
        public bool CheckPowerOfTwo(int n)
        {
            int power = 1;

            while (power <= n)
            {
                if (power == n)
                    return true;

                power *= 2;
            }
            return false;
        }

        public bool CheckPowerOfTwoUsingLog(int n)
        {
            double log = Math.Log(n, 2);

            // check for tolerence epsilon
            double epsilon = 1e-10;  // e => x 10 to the power of, epsilon is equivalent to 0.0000000001 or 1/10^-10

            return Math.Abs(log - Math.Round(log)) <= epsilon;
        }

        public double GetPower(int n, int power)
        {
            double log = Math.Log(n, power);

            double epsilon = 1e-10;

            if (Math.Abs(log - Math.Round(log)) <= epsilon)
                log = Math.Round(log);

            return log;
        }
    }
}
