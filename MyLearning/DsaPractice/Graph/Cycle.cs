using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsaPractice.Graph
{
    internal class Cycle
    {
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

        public bool HasCycle(Node node) => BFS(node);

        public bool BFS(Node node)
        {
            Queue<(Node node, int parent)> queue = new();

            var visited = new HashSet<int>();
            visited.Add(node.val);
            queue.Enqueue((node, -1));

            while (queue.Count > 0)
            {
                var (current, parent) = queue.Dequeue();

                Console.WriteLine(current.val);

                foreach (var edge in current.neighbors)
                {
                    if (!visited.Contains(edge.val))
                    {
                        visited.Add(edge.val);
                        queue.Enqueue((edge, current.val)); // track parent
                    }
                    else if (edge.val != parent)
                        return true;
                }
            }

            return false;
        }

        private bool DFS((Node node, Node? parent) current, HashSet<Node> visited)
        {
            foreach (var edge in current.node.neighbors)
            {
                if (!visited.Contains(edge))
                {
                    visited.Add(edge);

                    if (DFS((edge, current.node), visited))
                        return true;
                }
                else if (edge != current.parent)
                    return true;
            }

            return false;
        }

        public bool HasCycleDFS(Node node) => DFS((node, null), new HashSet<Node>() { node });

        public void Test()
        {
            /*
             *   1 — 2 — 3
                 \      /
                   — 4 —
                                1
               / \
              2 - 3
               \ / 
                4

            */
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

            // bool hasCycles = HasCycle(one);

            bool hasCycles = HasCycleDFS(one);

            Console.WriteLine(hasCycles);
        }
    }
}
