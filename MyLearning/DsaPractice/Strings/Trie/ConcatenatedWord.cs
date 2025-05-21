using DsaPractice.Trees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsaPractice.Strings.Trie
{
    internal class ConcatenatedWord : Trie
    {
        private bool CanFormContanatedWord(string word, int index, int count)
        {
            var node = Root;

            for (int i = index; i < word.Length; i++)
            {
                char c = word[i];

                if (!node.Children.ContainsKey(c))
                    return false;

                node = node.Children[c];

                if (node.Word != null)
                {
                    if (i == word.Length - 1)
                        return count >= 1; // Must form with 2+ words

                    if (CanFormContanatedWord(word, i + 1, count + 1))
                        return true;
                }
            }

            return false;
        }

        public List<string> GetContenatedWords(string[] words) =>
            words.Where(word => CanFormContanatedWord(word, 0, 0)).ToList();

        public override void FillTrieWithSampleDataAndTest()
        {
            string[] strings = { "cat", "cats", "dog", "catsdog", "catdog", "mouse", "catmouse" };

            foreach (var item in strings)
            {
                Insert(item);
            }

            Console.WriteLine(string.Join(", ", GetContenatedWords(strings)));
        }
    }
}
