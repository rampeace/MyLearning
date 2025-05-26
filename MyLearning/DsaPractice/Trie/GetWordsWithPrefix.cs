using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsaPractice.Trie
{
    internal class GetWordsWithPrefix
    {
        private readonly Trie _trie = new Trie();

        public List<string> GetWordsHavingPrefix(string prefix)
        {
            var node = _trie.Root;

            foreach (var c in prefix)
            {
                if (!node.Children.ContainsKey(c))
                    return new List<string>();

                node = node.Children[c];
            }

            List<string> words = new List<string>();
            DFS(node, words);
            return words;
        }

        private void DFS(TrieNode node, List<string> result)
        {
            if (node == null) return;

            if (node.Word != null)
                result.Add(node.Word);

            foreach (var childNode in node.Children.Values)
            {
                DFS(childNode, result);
            }
        }

        public void Test()
        {
            _trie.PopuateTrie();

            Console.WriteLine(string.Join(", ", GetWordsHavingPrefix("ca")));
            Console.WriteLine(string.Join(", ", GetWordsHavingPrefix("தா")));
        }
    }
}
