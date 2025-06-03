using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsaPractice.Graph
{
    /*
     * https://leetcode.com/problems/word-ladder/
     * 
     * A transformation sequence from word beginWord to word endWord using a dictionary wordList is a sequence of words:
     *     beginWord -> s1 -> s2 -> ... -> sk
     * such that:
     *   - Every adjacent pair of words differs by a single letter.
     *   - Every si for 1 <= i <= k is in wordList. Note that beginWord does not need to be in wordList.
     *   - sk == endWord
     * 
     * Given two words, beginWord and endWord, and a dictionary wordList, return the number of words in the shortest
     * transformation sequence from beginWord to endWord, or 0 if no such sequence exists.
     */
    internal class WordLadder
    {
        private bool isEdge(string one, string two)
            => one.Length == two.Length && Enumerable.Range(0, one.Length).Count(i => one[i] != two[i]) == 1;

        public int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            HashSet<string> seen = [.. wordList];
            
            if (!seen.Contains(endWord)) 
                return 0;

            Queue<(string word, int steps)> queue = new Queue<(string, int)>();
            queue.Enqueue((beginWord, 1)); // Start counting from 1

            while (queue.Count > 0)
            {
                var (current, steps) = queue.Dequeue();

                List<string> toRemove = new List<string>(); // To avoid modifying the set during iteration

                foreach (string word in seen)
                {
                    if (isEdge(current, word))
                    {
                        if (word == endWord)
                            return steps + 1;

                        queue.Enqueue((word, steps + 1));
                        toRemove.Add(word);
                    }
                }

                foreach (var word in toRemove) 
                    seen.Remove(word); // Safely remove visited words
            }
            return 0;
        }

        public int LadderLengthOptimal(string beginWord, string endWord, IList<string> wordList)
        {
            HashSet<string> seen = [..wordList];

            if (!seen.Contains(endWord))
                return 0;

            Queue<(string word, int steps)> queue = new();
            queue.Enqueue((beginWord, 1)); // Start counting from 1

            while (queue.Count > 0)
            {
                var (current, steps) = queue.Dequeue(); // Tuple deconstruction

                for (int i = 0; i < current.Length; i++)
                {
                    char[] chars = current.ToCharArray();

                    for (char c = 'a'; c <= 'z'; c++)
                    {
                        if (chars[i] == c)
                            continue;

                        chars[i] = c;

                        string wordToTry = new string(chars);

                        if (seen.Contains(wordToTry))
                        {
                            if (wordToTry == endWord)
                                return steps + 1;

                            queue.Enqueue((wordToTry, steps + 1));
                            seen.Remove(wordToTry); // Mark as visited
                        }
                    }
                }
            }
            return 0;
        }
        
        public void Test()
        {
            List<string> wordList = ["hot", "dot", "lot", "dog", "log", "cog"];
          //  List<string> wordList = ["hot", "dot", "dog", "lot", "log"];
            string beginWord = "hit";
            string endWord = "cog";

            //int count = LadderLength(beginWord, endWord, wordList);
            int count = LadderLengthOptimal(beginWord, endWord, wordList);

            Console.WriteLine(count);
        }
    }
}
