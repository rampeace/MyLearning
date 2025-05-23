using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsaPractice.Strings
{
    internal class ReverseVowels
    {
        /*
         *  Leetcode: 345
            Given a string s, reverse only all the vowels in the string and return it.
            The vowels are 'a', 'e', 'i', 'o', and 'u', and they can appear in both lower and upper cases, more than once.
        */
        public string ReverseVowelsOfAString(string s)
        {
            int left = 0;
            int right = s.Length - 1;
            char[] chars = s.ToCharArray();
            HashSet<char> vowels = "AEIOUaeiou".ToHashSet();

            while (left < right) 
            {
                if (!vowels.Contains(chars[left]))
                {
                    left++;
                }
                else if (!vowels.Contains(chars[right]))
                {
                    right--;
                }
                else
                {
                    char temp = chars[left];
                    chars[left] = chars[right];
                    chars[right] = temp;
                    left++;
                    right--;
                }
            }

            return new string(chars);
        }

        public void Test()
        {
            //string s = "IceCreAm";
            string s = "leetcode";
            Console.WriteLine(ReverseVowelsOfAString(s)); // Output: "AceCreIm"
        }
    }
}
