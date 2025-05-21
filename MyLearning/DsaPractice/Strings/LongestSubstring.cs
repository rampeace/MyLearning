using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsaPractice.Strings
{
    internal class LongestSubstring
    {
        public string LongestSubstringWithoutRepeatingCharacters(string text)
        {
            // "abcabcbb" Sliding window technique
            HashSet<char> seen = new();
            int windowStart = 0;
            int maxLength = 0;
            Range range = default;

            for (int windowEnd = 0; windowEnd < text.Length; windowEnd++)
            {
                char c = text[windowEnd];

                while(seen.Contains(c))
                {
                    seen.Remove(text[windowStart]);
                    windowStart++;
                }

                int windowLength = windowEnd - windowStart + 1;
                if (windowLength > maxLength) 
                {
                    maxLength = windowLength;
                    range = windowStart..(windowEnd + 1);
                }
                seen.Add(c);
            }

            return text[range];
        }

        public void Test()
        {
            Console.WriteLine(LongestSubstringWithoutRepeatingCharacters("abcabczbb"));
        }
    }
}
