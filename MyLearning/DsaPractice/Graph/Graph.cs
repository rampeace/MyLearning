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

        public void Dijkstra(Node start, Node end)
        {
            var distances = new Dictionary<Node, int>();
            var previous = new Dictionary<Node, Node>();
            var priorityQueue = new SortedSet<(int, Node)>(Comparer<(int, Node)>.Create((a, b) =>
            {
                int result = a.Item1.CompareTo(b.Item1);
                if (result == 0)
                    return a.Item2.Id.CompareTo(b.Item2.Id);
                return result;
            }));

            foreach (var node in _adjacencyList.Keys)
            {
                distances[node] = int.MaxValue;
            }
            distances[start] = 0;
            priorityQueue.Add((0, start));

            while (priorityQueue.Count > 0)
            {
                var min = priorityQueue.Min;
                int currentDistance = min.Item1;
                Node currentNode = min.Item2;
                priorityQueue.Remove(min);

                if (currentNode.Equals(end))
                    break;

                foreach (var edge in _adjacencyList[currentNode])
                {
                    int newDist = currentDistance + edge.Weight;
                    if (newDist < distances[edge.To])
                    {
                        // Remove old entry if it exists
                        priorityQueue.Remove((distances[edge.To], edge.To));
                        distances[edge.To] = newDist;
                        previous[edge.To] = currentNode;
                        priorityQueue.Add((newDist, edge.To));
                    }
                }
            }

            if (!previous.ContainsKey(end))
            {
                Console.WriteLine($"No route from {start} to {end}");
                return;
            }

            var path = new Stack<Node>();
            for (var at = end; at != null; at = previous.GetValueOrDefault(at))
                path.Push(at);

            Console.WriteLine($"Shortest path from {start} to {end}:");
            Console.WriteLine(string.Join(" -> ", path));
            Console.WriteLine($"Total Distance: {distances[end]}");
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
