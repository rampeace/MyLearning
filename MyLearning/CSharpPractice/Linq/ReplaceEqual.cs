using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice.Linq
{
    internal class ReplaceEqual
    {
        public void FindReplaceEqual()
        {
            int[] array1 = { 10, 6, 8, 3, 5, 8 };
            int[] array2 = { 10, 6, 8, 3, 5 };

            var result = array1
                .Where((_, index) => array1.Where((_, index2) => index2 != index).SequenceEqual(array2))
                .FirstOrDefault();

            Console.WriteLine((result == default) ? "No such number found." : result.ToString());
        }
    }
}
