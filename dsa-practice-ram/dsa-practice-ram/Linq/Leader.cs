using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dsa_practice_ram.Linq
{
    internal class Leader
    {
        public void FindLeader()
        {
            // Extreme brute force solultion - not effecient Time Complexity O(n^2)
            int[] input = { 10, 22, 12, 3, 0, 6 };

            var result = input
                .Where((num, index) => index == input.Length - 1 || input.Skip(index + 1).All(num2 => num2 < num));

            Console.WriteLine(string.Join(", ", result));
        }
    }
}
