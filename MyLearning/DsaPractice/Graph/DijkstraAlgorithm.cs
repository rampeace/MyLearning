using System;
using System.Collections.Generic;
using System.Text;

namespace DsaPractice.Graph
{
    /*
     *  In BFS, the first discovery is the shortest path. We don't enqueue the same node again in BFS.
     *  To find shortest paths in weighted graphs, we need to allow re-enqueue and compare the shortest paths—standard BFS won't allow this.
     *  BFS assumes the first discovery is the shortest path (valid in unweighted graphs).
     *  
     *  Dijkstra’s algorithm will re-enqueue the same node if it finds a shorter path — that’s the key difference from classic BFS!
     *  
     *  How does Dijkstra’s algorithm avoid visited node tracking?
     *  
     *  1️ It uses a priority queue (min-heap) to always pick the next unvisited node with the smallest distance.
     *  2️ When it visits a node, it marks it as “visited” (like crossing it off a to-do list).
     *  3️ It only processes each node once — even if there’s a cycle in the graph, once a node’s shortest distance is found, 
     *  the algorithm doesn’t revisit it.
     */
    internal class DijkstraAlgorithm
    {
        public class Edge(int to, int weight)
        {
            public int To { get; } = to;

            public int Weight { get; } = weight;
        }

        public int[] Dijkstra(List<List<Edge>> adjacencyList, int source)
        {
            int nodes = adjacencyList.Count;

            int[] distances = [..Enumerable.Range(0, nodes).Select(node => node == source ? 0 : int.MaxValue)];

            PriorityQueue<int, int> priorityQueue = new();
            priorityQueue.Enqueue(source, 0);

            while(priorityQueue.Count > 0)
            {
                priorityQueue.TryDequeue(out int current, out int currentDistance);

                foreach (var to in adjacencyList[current])
                {
                    int newDistance = currentDistance + to.Weight;
                    int existingDistance = distances[to.To];

                    if (newDistance >= existingDistance)
                        continue;

                    distances[to.To] = newDistance;
                    priorityQueue.Enqueue(to.To, newDistance);
                }
            }

            return distances;
        }        

        public void Test()
        {
            int nodes = 5;

            List<List<Edge>> adj = [
                [ new Edge(1, 2), new Edge(2, 4) ],     // Node 0
                [ new Edge(2, 1), new Edge(3, 7) ],     // Node 1
                [ new Edge(4, 3) ],                     // Node 2
                [ new Edge(4, 1) ],                     // Node 3
                [ ]                                     // Node 4
            ];

            int[] distances = Dijkstra(adj, 0);

            for (int node = 0; node < distances.Length; node++)
            {
                Console.WriteLine($"Node {node} -> Shortest Distance: {distances[node]}");
            }
        }
    }
}
