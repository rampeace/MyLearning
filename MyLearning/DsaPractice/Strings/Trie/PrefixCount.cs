using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsaPractice.Strings.Trie
{
    internal class PrefixCount
    {
        internal class TrieNode
        {
            public Dictionary<char, TrieNode> Children { get; } = new Dictionary<char, TrieNode>();

            public bool IsWord { get; set; }

            public int PrefixCount { get; set; }
        }

        TrieNode _root = new TrieNode();


        public void Insert(string word)
        {
            TrieNode node = _root;

            foreach (var c in word)
            {
                if (!node.Children.ContainsKey(c))
                    node.Children[c] = new TrieNode();

                node = node.Children[c];
                node.PrefixCount++; // required if for prefix count without using DFS
            }

            node.IsWord = true;
        }

        public int PrefixCountUsingDFS(string prefix)
        {
            var node = _root;

            foreach (var c in prefix)
            {
                if (!node.Children.ContainsKey(c))
                    return 0;

                node = node.Children[c];
            }

            return DFS(node);
        }

        private int DFS(TrieNode node)
        {
            int count = 0;

            if (node.IsWord)
                count++;

            foreach (var childNode in node.Children.Values)
            {
                count += DFS(childNode);
            }

            return count;
        }

        public int PrefixCountWithoutDFS(string prefix)
        {
            var node = _root;

            foreach (var c in prefix)
            {
                if (!node.Children.ContainsKey(c))
                    return 0;

                node = node.Children[c];
            }
            return node.PrefixCount;
        }

        public void FillTrieWithSampleDataAndTest()
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

            Console.WriteLine(PrefixCountUsingDFS("ca"));
            Console.WriteLine(PrefixCountWithoutDFS("ca"));
        }
    }
}
