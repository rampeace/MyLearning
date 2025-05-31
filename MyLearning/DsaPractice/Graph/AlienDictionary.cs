using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DsaPractice.Graph
{
    /*
         * https://www.geeksforgeeks.org/problems/alien-dictionary/1
         * 
         * A new alien language uses the English alphabet, but the order of letters is unknown. 
         * You are given a list of words[] from the alien language’s dictionary, where the words 
         * are claimed to be sorted lexicographically according to the language’s rules.
         *
         * Your task is to determine the correct order of letters in this alien language based on 
         * the given words. If the order is valid, return a string containing the unique letters in 
         * lexicographically increasing order as per the new language's rules. If there are multiple 
         * valid orders, return any one of them.
         *
         * However, if the given arrangement of words is inconsistent with any possible letter ordering, 
         * return an empty string ("").
         *
         * A string a is lexicographically smaller than a string b if, at the first position where they 
         * differ, the character in a appears earlier in the alien language than the corresponding 
         * character in b. If all characters in the shorter word match the beginning of the longer word, 
         * the shorter word is considered smaller.
         *
         * Note: Your implementation will be tested using a driver code. It will print true if your 
         * returned order correctly follows the alien language’s lexicographic rules; otherwise, it will 
         * print false.
         */
    internal class AlienDictionary
    {
        public string AlienOrder(List<string> words)
        {
            // Build a graph, with what comes before what and apply Khan's algorithm
            // words[] = ["baa", "abcd", "abca", "cab", "cad"]

            // a hashset is required because in the alien dictionary point of view there could be multiple successors for one character
            Dictionary<char, HashSet<char>> adjacencyList = new();

            // Indegree   A -> B -> C
            //           ^   ^    ^
            Dictionary<char, int> inDegrees = new();

            // Graph should include all the characters including those which we can't figure out edges
            foreach (var c in words.SelectMany(word => word))
            {
                adjacencyList[c] = new HashSet<char>();
                inDegrees[c] = 0;
            }

            for (int i = 0; i < words.Count - 1; i++)
            {
                string first = words[i];
                string second = words[i + 1];

                bool differenceFound = false;

                int j = 0;

                while (j < first.Length && j < second.Length)
                {
                    char c1 = first[j];
                    char c2 = second[j];

                    if (c1 != c2)
                    {
                        // Add edge only if it doesn't already exist to avoid duplicate edges
                        // which would cause incorrect in-degree counts.
                        if (!adjacencyList[c1].Contains(c2))
                        {
                            adjacencyList[c1].Add(c2);
                            inDegrees[c2]++;
                        }
                        differenceFound = true;
                        break; // Only the first difference matters
                    }

                    j++;
                }

                if (!differenceFound && first.Length > second.Length)
                {
                    // abcdef vs abc => abc should come first
                    return string.Empty;
                }
            }

            Queue<char> queue = new();

            foreach (var indegree in inDegrees)
            {
                if (indegree.Value == 0)
                    queue.Enqueue(indegree.Key);
            }

            StringBuilder result = new();

            while(queue.Any())
            {
                char current = queue.Dequeue();
                result.Append(current);

                foreach (var edge in adjacencyList[current])
                {
                    inDegrees[edge]--;

                    if (inDegrees[edge] == 0)
                        queue.Enqueue(edge);
                }
            }

            // cycle detection
            return result.Length == adjacencyList.Count ? result.ToString() : string.Empty;
        }

        public void Test()
        {
            List<string> words = [ "baa", "abcd", "abca", "cab", "cad" ];
            string order = AlienOrder(words);

            Console.WriteLine(order);
        }
    }
}
