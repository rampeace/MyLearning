using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsaPractice.Strings.Trie
{
    internal class Trie
    {

        /*
             ["cat", "cap", "can"]

                      (root)
                         |
                         c
                         |
                         a
                       / | \
                      t  p  n

        */

        TrieNode _root = new TrieNode();

        public void Insert(string word)
        {
            TrieNode node = _root;

            foreach (var c in word)
            {
                if (!node.Children.ContainsKey(c))
                    node.Children[c] = new TrieNode();

                node = node.Children[c];
            }

            node.Word = word;
        }

        public bool Search(string word)
        {
            TrieNode node = _root;

            foreach (var c in word)
            {
                if (!node.Children.ContainsKey(c))
                    return false;

                node = node.Children[c];
            }

            return node.Word != null;
        }

        public List<string> GetWordsWithPrefix(string prefix)
        {
            var node = _root;

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

        public void DFS(TrieNode node, List<string> result)
        {
            if (node == null) return;

            if (node.Word != null)
                result.Add(node.Word);

            foreach (var childNode in node.Children.Values)
            {
                DFS(childNode, result);
            }
        }

        public void TestWordsWithPrefix()
        {
            Insert("carpool");
            Insert("cat");
            Insert("can");
            Insert("car");
            Insert("ca");
            Insert("ram");

            Insert("தாய்");
            Insert("தாமரை");
            Insert("தாதா");
            Insert("தாங்கு");

            Console.WriteLine(string.Join(", ", GetWordsWithPrefix("ca")));
            Console.WriteLine(string.Join(", ", GetWordsWithPrefix("தா")));
        }
    }
}
