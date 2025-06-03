using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DsaPractice.Graph
{
    public class Node(int id, string name)
    {
        public int Id { get; } = id;

        public string Name { get; } = name;

        public override bool Equals(object obj) => obj is Node node && Id == node.Id;

        public override int GetHashCode() => Id.GetHashCode();

        public override string ToString() => Name;
    }

    public class Edge
    {
        public Node From { get; }
        public Node To { get; }
        public int Weight { get; }

        public Edge(Node from, Node to, int weight)
        {
            From = from;
            To = to;
            Weight = weight;
        }

        public override string ToString()
        {
            return $"{From} --({Weight})-- {To}";
        }
    }

    public class Graph
    {
        private readonly Dictionary<Node, List<Edge>> _adjacencyList = new();

        public void AddNode(Node node)
        {
            if (!_adjacencyList.ContainsKey(node))
                _adjacencyList[node] = new List<Edge>();
        }

        public void AddEdge(Node from, Node to, int weight)
        {
            AddNode(from);
            AddNode(to);

            var edge = new Edge(from, to, weight);
            var reverseEdge = new Edge(to, from, weight); // undirected

            _adjacencyList[from].Add(edge);
            _adjacencyList[to].Add(reverseEdge);
        }

        public void DFS(Node start)
        {
            var visited = new HashSet<Node>();
            Console.WriteLine("DFS Traversal:");
            DFSUtil(start, visited);
        }

        private void DFSUtil(Node node, HashSet<Node> visited)
        {
            if (visited.Contains(node))
                return;

            Console.WriteLine(node);
            visited.Add(node);

            foreach (var edge in _adjacencyList[node])
            {
                DFSUtil(edge.To, visited);
            }
        }

        public void BFS(Node start)
        {
            var visited = new HashSet<Node>();
            var queue = new Queue<Node>();
            queue.Enqueue(start);
            visited.Add(start);

            Console.WriteLine("BFS Traversal:");
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                Console.WriteLine(current);

                foreach (var edge in _adjacencyList[current])
                {
                    if (!visited.Contains(edge.To))
                    {
                        visited.Add(edge.To);
                        queue.Enqueue(edge.To);
                    }
                }
            }
        }

        public void PrintGraph()
        {
            Console.WriteLine("Graph structure:");
            foreach (var kvp in _adjacencyList)
            {
                Console.Write($"Node {kvp.Key.Id}: ");
                foreach (var edge in kvp.Value)
                {
                    Console.Write($"-> {edge.To.Id}({edge.Weight}) ");
                }
                Console.WriteLine();
            }
        }
    }
}
