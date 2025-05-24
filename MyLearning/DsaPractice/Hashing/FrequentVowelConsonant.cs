using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsaPractice.Hashing
{
    internal class FrequentVowelConsonant
    {
        /*
         * Leetcode: 3541  Find Most Frequent Vowel and Consonant
         *
         */
        public int MaxFreqSum(string s)
        {
            HashSet<char> vowels = "AEIOUaeiou".ToHashSet();

            return s
            .GroupBy(c => vowels.Contains(c))
            .Sum(g => g.GroupBy(c => c).Max(g => g.Count()));
        }
    }
}
