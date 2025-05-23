using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsaPractice.Hashing
{
    internal class UniqueOccurances
    {
        public bool AreUniqueOccurances(int[] arr)
        {
            return arr
               .GroupBy(num => num)
               .Select(g => new
               {
                   Occurance = g.Count()
               })
               .GroupBy(o => o.Occurance)
               .All(g => g.Count() == 1);
        }

        public void Test()
        {
            int[] arr = [1, 2, 2, 1, 1, 3, 4];
            Console.WriteLine(AreUniqueOccurances (arr));
        }
    }
}
