using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice.Linq
{
    internal class FormPairs
    {
        public void MakePairs()
        {
            // Works only for two pairs not more than that 
            string[] strings = { "cat", "cats", "dog", "catsdog", "catdog" , "mouse", "catmouse"};

            var pairs = strings.SelectMany((_, i) => strings.Where((_, j) => i != j), (x, y) => $"{x}{y}").ToHashSet();

            var result = strings.Where(word => pairs.Contains(word));

            Console.WriteLine(string.Join(", ", result)); 
        }
    }
}
