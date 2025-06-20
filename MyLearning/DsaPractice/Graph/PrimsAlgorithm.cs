using System;
using System.Collections.Generic;
using System.Text;

namespace DsaPractice.Graph
{
/*
 * ===============================
 *   Graph Types
 * ===============================
 * Directed Graph:
 *   A → C → B → E
 *   - A is strictly the parent of C, C is strictly the parent of B, etc.
 * 
 * Undirected Graph:
 *   A — C — B — E
 *   - Edges are bidirectional; no strict parent-child relationship.
 * 
 * ===============================
 *   Prim’s Algorithm Output
 * ===============================
 * - A set of edges forming the MST (Minimum Spanning Tree).
 * - Optionally, a parent array indicating for each node which node brought it into the tree.
 * 
 * Why output the edges?
 * - The MST is defined by the collection of edges that connect all nodes with minimum total cost.
 * - Without the edges, the network cannot be visualized or reconstructed.
 * 
 * Typical Prim’s MST Output (Edges List):
 *   (from_node, to_node, weight)
 *   Example:
 *     (A, C, 2)
 *     (A, B, 10)
 *     (C, E, 12)
 *   - Shows which edges to build, which nodes are connected, and the weight of each edge.
 * 
 * ===============================
 *   Example: Step-by-Step
 * ===============================
 * Step 1️⃣: Build the Graph
 *   Nodes: A, B, C, E
 *   Edges:
 *     A — B (weight 10)
 *     A — C (weight 2)
 *     C — E (weight 12)
 * 
 * Step 2️⃣: Apply Prim’s Algorithm (Start from A)
 *   2.1: Start at A
 *     - Add A to the MST.
 *     - Edges to pick: A—B (10), A—C (2)
 *     - Pick A—C (2)
 *   2.2: Add C to the MST ({A, C})
 *     - Edges: A—B (10), C—E (12)
 *     - Pick A—B (10)
 *   2.3: Add B to the MST ({A, C, B})
 *     - Edges: C—E (12)
 *     - Pick C—E (12)
 *   2.4: Add E to the MST ({A, C, B, E})
 *     - All nodes included. Done!
 * 
 * Step 3️⃣: MST Summary
 *   Edges selected:
 *     A—C (2)
 *     A—B (10)
 *     C—E (12)
 *   Total Weight: 2 + 10 + 12 = 24
 * 
 * ===============================
 *   What Matters
 * ===============================
 * - You must build all three edges (A—C, A—B, C—E) to form a connected MST.
 * - The order does not matter (e.g., A—B first, then A—C, then C—E).
 * - Do NOT skip any recommended edge (network would be disconnected).
 * - Do NOT add extra edges (could create a cycle and increase total cost).
     *  Directed Graph:

A → C → B → E
Here, A is strictly the parent of C, C is strictly the parent of B, and so on.

 Undirected Graph:

A — C — B — E
Here, edges are bidirectional: there’s no strict parent-child defined just by the edge itself.
     * 
     * What Prim’s Algorithm actually gives us:

A set of edges that together form the MST (Minimum Spanning Tree).

A parent array (optional, but useful) that tells you, for each node, which other node brought it into the tree.

Why we need to output the edges:
Because the MST is defined by the collection of edges that together connect all nodes with the minimum total cost.
Without the edges, we can’t visualize the network or even know how to reconstruct it.

Typical Prim’s MST Output
Edges list:
Usually we output each edge as:

(from_node, to_node, weight)
Example:
(A, C, 2)
(A, B, 10)
(C, E, 12)
This way you know exactly:

Which edges to build

Which nodes are connected

What the weight of each edge is

    Step 1️⃣: Build the Graph
Let’s name the nodes:

A

B

C

E

And the edges:

A — B (weight 10)

A — C (weight 2)

C — E (weight 12)

Step 2️⃣: Apply Prim’s Algorithm
Let’s assume we start Prim’s algorithm from A.

Step 2.1: Start at A

Add A to the MST.

The edges we can pick are:

A — B (10)

A — C (2)

Pick the lowest weight edge → A — C (2)

Step 2.2: Add C to the MST

Now the MST has nodes: {A, C}

The edges to consider:

A — B (10)

C — E (12)

Pick the lowest weight → A — B (10)

Step 2.3: Add B to the MST

Now the MST has nodes: {A, C, B}

The edges to consider:

C — E (12)

Pick the only remaining edge → C — E (12)

Step 2.4: Add E to the MST

Now the MST has nodes: {A, C, B, E}

All nodes included. Done!

Step 3️⃣: Summary of Prim’s MST
Edges selected:
A — C (2)
A — B (10)
C — E (12)

Total Weight:
2 + 10 + 12 = 24

    What matters:
 You must build all three edges (A—C, A—B, and C—E) to form a connected MST.
The order you build them in is not important — for example:

You could build A—B first, then A—C, then C—E.

Or A—C first, then C—E, then A—B.

What you should not do:
Skip any recommended edge (because then the network is disconnected).
    Add extra edges that aren’t part of the MST (because that could create a cycle and increase total cost).
*/
    internal class PrimsAlgorithm
    {
        public (int totalWeight, int[] mst) MinimumSpanningTree(int n, List<(int from, int to, int weight)> edges)
        {
            List<List<(int to, int weight)>> adjacencyList = 
                [..Enumerable.Range(0, n).Select(_ => new List<(int to, int weight)>())];

            foreach (var (from, to, weight) in edges)
            {
                adjacencyList[from].Add((to, weight));
                adjacencyList[to].Add((from, weight));
            }

            int[] parents = [..Enumerable.Repeat(-1, n)];
            int totalWeight = 0;

            PriorityQueue<(int parent, int to, int weight), int> priorityQueue = new();
            priorityQueue.Enqueue((-1, 0, 0), 0);

            // A -> B                   Not Possible         => Storing parents[from] = to is not possible, because from can be multiple
            // A -> C -> D -> B         A -> B and C -> B 

            while(priorityQueue.Count > 0)
            {
                var (parent, to, weight) = priorityQueue.Dequeue();

                if (parents[to] != -1)
                    continue;

                parents[to] = parent;

                totalWeight += weight;

                foreach (var edge in adjacencyList[to])
                {
                    if (parents[edge.to] == -1)
                        priorityQueue.Enqueue((to, edge.to, edge.weight), edge.weight);
                }
            }

            return (totalWeight, parents);
        }
        public void Test()
        {
            int n = 5;
            var edges = new List<(int, int, int)>
            {
                (0, 1, 2),
                (0, 3, 6),
                (1, 2, 3),
                (1, 3, 8),
                (1, 4, 5),
                (2, 4, 7),
                (3, 4, 9)
            };

            var (totalWeight, mst) = MinimumSpanningTree(n, edges);

            Console.WriteLine($"Total MST Weight: {totalWeight}");

            Console.WriteLine(string.Join(", ", mst));
        }
    }
}
