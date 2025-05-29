using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsaPractice.Graph
{

    /*
         * ┌─────────────────────────────┐
         * │        Disjoint Sets        │
         * └─────────────────────────────┘
         * 
         * Example:
         *   Set A = { apple, banana }
         *   Set B = { carrot, tomato }
         *   => Sets A and B are disjoint (no shared items).
         * 
         * General Definition:
         *   - No shared elements.
         *   - Not related to edges or connections.
         * 
         * In Graphs:
         *   - Disjointness: no shared vertices between the two sets.
         * 
         * ┌─────────────────────────────┐
         * │      Bipartite Property     │
         * └─────────────────────────────┘
         *   - Adds a rule: connections (edges) are allowed
         *     only between the sets, never within a set.
         *   - There may be multiple valid splits, but not every split works.
         * 
         * If at least one valid split exists where:
         *   - No two nodes within a set are connected by an edge,
         *   - And all edges go between the sets,
         *   → Then the graph is bipartite.
         * 
         * But if no such split exists, then the graph is not bipartite.
         * 
         * If a graph has no odd-length cycles, then we can always color it using 2 colors,
         * such that no two adjacent nodes have the same color.
         *   - No odd-length cycles: A bipartite graph cannot contain any odd-length cycles,
         *     as this would require vertices from the same set to be connected by an edge.
         * 
         * The goal is to separate connected nodes into opposite groups.
         * 
         * Most real-world graphs aren’t purely bipartite. But when solving problems like matching, assignment, classification,
         * we often build or extract a bipartite view of the data to make the algorithms work.
         */

    internal class Bipartite
    {
        public bool IsBipartite(int[][] graph)
        {
            int rows = graph.Length;
            char[] colors = new char[rows];
            colors[0] = 'B'; // start with black

            return DFS(graph, 0, colors);
        }

        private bool DFS(int[][] graph, int node, char[] colors)
        {
            // Black, White
            // [[1,2,3],[0,2],[0,1,3],[0,2]]

            /*
             *           A (B)
             *         /    \
             *         B(W)     C(W)
             *       /    \
             *       D(W)
             *         
             *           
                */

            char flippedColor = colors[node] == 'B' ? 'W' : 'B';

            foreach (var edge in graph[node])
            {
                char neighbourColor = colors[edge];

                if (neighbourColor == '\0')
                {
                    colors[edge] = flippedColor;  
                    
                    if (!DFS(graph, edge, colors))
                        return false;
                }
                else if(neighbourColor == colors[node]) 
                {
                    return false;
                }                
            }

            return true;
        }
        public bool IsBipartiteBFS(int[][] graph) => BFS(graph, 0);

        private bool BFS(int[][] graph, int start)
        {
            char[] colors = new char[graph.Length];
            colors[start] = 'B'; // start with black

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                int current = queue.Dequeue();

                foreach (var neighbour in graph[current])
                {
                    char neighbourColor = colors[neighbour];

                    if (neighbourColor == '\0')
                    {
                        colors[neighbour] = colors[current] == 'B' ? 'W' : 'B';
                        queue.Enqueue(neighbour);
                    }
                    else if (neighbourColor == colors[current])
                        return false;

                }
            }

            return true;
        }

        public void Test()
        {
            int[][] graph = [[1, 2, 3], [0, 2], [0, 1, 3], [0, 2]];

            //int[][] graph = [[1, 3], [0, 2], [1, 3], [0, 2]];

            //Console.WriteLine(IsBipartite(graph));

            Console.WriteLine(IsBipartiteBFS(graph));
        }
    }
}
