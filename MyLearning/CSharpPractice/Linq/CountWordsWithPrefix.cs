using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice.Linq
{
    internal class CountWordsWithPrefix
    {
        public void CountWordsWithPrefixUsingLinq()
        {
            string[] words = {"apple", "app", "application", "ape", "bat", "ball"};

            string prefix = "ap";

            int count = words.Count(word => word.StartsWith(prefix));

            Console.WriteLine(count);
        }
    }
}
