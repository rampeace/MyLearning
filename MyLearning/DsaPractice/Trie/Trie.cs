using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsaPractice.Trie
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

        public TrieNode Root { get; } = new TrieNode();

        public void Insert(string word)
        {
            TrieNode node = Root;

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
            TrieNode node = Root;

            foreach (var c in word)
            {
                if (!node.Children.ContainsKey(c))
                    return false;

                node = node.Children[c];
            }

            return node.Word != null;
        }

        public void PopuateTrie(IEnumerable<string> strings = null)
        {
            if (strings == null)
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
            }
            else
            {
                foreach (var item in strings)
                {
                    Insert(item);
                }
            }
        }
    }
}
