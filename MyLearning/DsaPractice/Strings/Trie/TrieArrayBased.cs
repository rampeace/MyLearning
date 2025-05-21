using DsaPractice.Trees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsaPractice.Strings.Trie
{
    internal class TrieArrayBased
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
        internal class TrieNode
        {
            public TrieNode[] Children = new TrieNode[26]; // supports only a-z

            public string? Word { get; set; }
        }

        TrieNode _root = new TrieNode();

        public void Insert(string word)
        {
            var node = _root;

            foreach (var c in word)
            {
                int index = c - 'a';

                if (node.Children[index] == null)
                    node.Children[index] = new TrieNode();

                node = node.Children[index];
            }
            node.Word = word;
        }

        public bool Search(string word)
        {
            var node = _root;

            foreach (var c in word)
            {
                int index = c - 'a';

                if (node.Children[index] == null)
                    return false;

                node = node.Children[index];
            }

            return node.Word != null;
        }
        public List<string> GetWordsWithPrefix(string prefix)
        {
            var node = _root;

            foreach (var c in prefix)
            {
                int index = c - 'a';

                if (node.Children[index] == null)
                    return new List<string>();

                node = node.Children[index];
            }

            List<string> words = new List<string>();
            DFS(node, words);
            return words;
        }

        private void DFS(TrieNode node, List<string> words)
        {
            if (node == null) return;

            if (node.Word != null)
                words.Add(node.Word);

            for (int i = 0; i < 26; i++)
            {
                if (node.Children[i] != null)
                    DFS(node.Children[i], words);
            }
        }

        public void TestSearchWords()
        {
            Insert("cat");
            Insert("car");
            Insert("carpool");
            Insert("can");
            Insert("cen");

            Console.WriteLine(Search("carpool"));
            Console.WriteLine(string.Join(", ", GetWordsWithPrefix("ca")));
        }
    }
}
