using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsaPractice.Graph
{
    internal class BFS
    {
        // Leetcode style undirected class
        public class Node
        {
            public int val;
            public IList<Node> neighbors;

            public Node()
            {
                val = 0;
                neighbors = new List<Node>();
            }

            public Node(int _val)
            {
                val = _val;
                neighbors = new List<Node>();
            }

            public Node(int _val, List<Node> _neighbors)
            {
                val = _val;
                neighbors = _neighbors;
            }
        }

        public void BFSGraph(Node node)
        { 
            Queue<Node> queue = new Queue<Node>();

            var visited = new HashSet<int>();
            visited.Add(node.val);
            queue.Enqueue(node);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                Console.WriteLine(current.val);

                foreach (var edge in current.neighbors)
                {
                    if (!visited.Contains(edge.val))
                    {
                        visited.Add(edge.val);
                        queue.Enqueue(edge);
                    }
                }
            }
        }

        public void Test()
        {
            Node one = new Node(1);
            Node two = new Node(2);
            Node three = new Node(3);
            Node four = new Node(4);    

            one.neighbors.Add(two);
            one.neighbors.Add(three);

            two.neighbors.Add(four);
            two.neighbors.Add(three);

            three.neighbors.Add(four);
            three.neighbors.Add(one);

            four.neighbors.Add(two);
            four.neighbors.Add(one);

            BFSGraph(one);                
        }
    }
}
