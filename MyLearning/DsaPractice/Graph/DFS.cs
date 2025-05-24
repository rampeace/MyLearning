using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsaPractice.Graph
{
    internal class DFS
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

        public void DFSGraph(Node node)
        {
            DFSUtil(node, new HashSet<int>());
        }

        private void DFSUtil(Node node, HashSet<int> visited)
        {
            if (node == null || visited.Contains(node.val))
                return;

            Console.WriteLine(node.val);
            visited.Add(node.val);

            foreach (var edge in node.neighbors)
            {
                DFSUtil(edge, visited);
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

            DFSGraph(one);
        }
    }
}
