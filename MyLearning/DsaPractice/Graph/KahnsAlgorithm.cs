using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsaPractice.Graph
{
    internal class KahnsAlgorithm
    {

        /*
         * ──────────────────────────────────────────────────────────────────────────────
         *   Kahn's Algorithm for Topological Sorting (with Real-World Context)
         * ──────────────────────────────────────────────────────────────────────────────
         * 
         * 1. Dependency Representation:
         *    - A directed edge u → v means "u must come before v" (v depends on u).
         *    - Nodes with no incoming edges (in-degree = 0) have no dependencies and can be processed first.
         * 
         * 2. Topological Sorting:
         *    - Ensures every node is processed only after all its dependencies have been processed.
         *    - Respects the dependency-before-dependent rule.
         * 
         * 3. Real-World Examples:
         *    • Build Systems (Make, Gradle, Bazel)
         *    • Package Managers (npm, pip, apt)
         *      - Analyze the dependency graph.
         *      - Topologically sort to install dependencies in the correct order.
         * 
         * 4. Example Graph:
         * 
         *         A 
         *       /   \
         *      B     C      // B and C depend on A
         *          /   \
         *         D     B   // B and D depend on C
         * 
         * 5. Why a DAG (Directed Acyclic Graph)?
         *    1️⃣ Directed: Edges point from dependency to dependent ("A → B" means "A before B").
         *    2️⃣ Acyclic: No cycles allowed—otherwise, a task indirectly depends on itself.
         *        - Example: A → B → C → A is a cycle—no valid order exists!
         * 
         * 6. Steps:
         *    - Clearly define tasks/nodes.
         *    - Draw edges from each dependency to the task that depends on it.
         *    - Ensure no cycles (circular dependencies are errors).
         * 
         * 7. Concurrency:
         *    - Kahn’s algorithm produces a linear ordering (A, B, C, D), but in real-world execution,
         *      some tasks can run in parallel.
         *    - At any step, all nodes with zero in-degree are independent and can be executed in parallel.
         *    - Processing zero in-degree nodes in batches gives concurrency groups ("levels" of execution).
         * 
         * 8. Applications:
         *    - Build Systems (Make, Bazel, Ninja)
         *    - Distributed Task Scheduling (Apache Airflow, Luigi)
         *    - Package Managers (npm, Maven, Gradle)
         * 
         * 9. Course Scheduling Problem:
         *    - numCourses: total courses labeled from 0 to numCourses - 1.
         *    - prerequisites[i] = [ai, bi]: to take course ai, you must first take course bi.
         *      • Example: [0, 1] means "to take course 0, first take course 1".
         *    - Return a valid ordering to finish all courses, or an empty array if impossible.
         * 
         * ──────────────────────────────────────────────────────────────────────────────
         *
        * A dependency in a directed graph is represented by a directed edge from one node (u) to another node (v):
        *     u → v  means "u must come before v" (v depends on u; u is a prerequisite for v).
        * 
        * In topological sorting, a dependency is represented as a directed edge:
        *     u → v
        *     - v is dependent on u (v can’t be processed until u is done).
        *     - Nodes with no incoming edges (in-degree = 0) have no dependencies and can be processed first.
        * 
        * Kahn’s algorithm ensures every node is processed only after all its dependencies have been processed,
        * respecting the dependency-before-dependent rule.
        * 
        * Real world examples:
        *   - Build Systems (Make, Gradle, Bazel)
        *   - Package Managers (npm, pip, apt)
        *     - When installing packages with dependencies (e.g., library A needs library B first), package managers:
        *         1. Analyze the dependency graph.
        *         2. Topologically sort it to install dependencies in the correct order.
        * 
        * Example:
        *         A 
        *       /   \
        *      B     C      => B and C are dependent on A
        *          /   \
        *         D     B   => B and D are dependent on C
        * 
        * Why must it be a DAG?
        *   1️⃣ Directed: Edges represent dependencies pointing from dependency to dependent (e.g., "A → B" means "A must come before B").
        *   2️⃣ Acyclic: No cycles allowed—otherwise, a task indirectly depends on itself, which is impossible to resolve.
        *      - Example: A → B → C → A is a cycle—no valid order exists to start!
        * 
        *   - Clearly define tasks or nodes.
        *   - Draw edges from each dependency to the task that depends on it.
        *   - Ensure no cycles (circular dependencies are errors).
        * 
        * Note: Kahn’s algorithm produces a linear ordering (A, B, C, D), but in real-world execution (build systems, schedulers),
        * some tasks can run in parallel—even though the topological sort lists them sequentially.
        * 
        * How to achieve concurrency using Kahn's Algorithm:
        *   - At any step, all nodes with zero incoming edges are independent and can be executed in parallel.
        *   - If you process all zero in-degree nodes in batches (instead of one by one), you get concurrency groups or "levels" of execution.
        * 
        * Many applications follow this pattern:
        *   - Build Systems (e.g., Make, Bazel, Ninja)
        *   - Distributed Task Scheduling (e.g., Apache Airflow, Luigi)
        *   - Package Managers (e.g., npm, Maven, Gradle)
        *   
        *   There are a total of numCourses courses you have to take, labeled from 0 to numCourses - 1. You are given an array prerequisites where prerequisites[i] = [ai, bi] indicates that you must take course bi first if you want to take course ai.

        For example, the pair [0, 1], indicates that to take course 0 you have to first take course 1.

        Return the ordering of courses you should take to finish all courses. If there are many valid answers, return any of them. If it is impossible to finish all courses, return an empty array.
                  A 
        *       /   \
        *      B     C      => B and C are dependent on A
        *          /   \
        *         D     B   => B and D are dependent on C
        *              /
        *             A
        */

        public int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            // Input: numCourses = 2, prerequisites = [[1,0]]

            // Build an adjacency list
            List<List<int>> adjacencyList = [.. Enumerable.Range(0, numCourses).Select(_ => new List<int>())];

            foreach (var edges in prerequisites)
            {
                int from = edges[1];
                int to = edges[0];

                adjacencyList[from].Add(to);
            }

            int[] inDegree = new int[numCourses];

            foreach (var from in adjacencyList)
            {
                foreach (var to in from)
                {
                    inDegree[to]++;
                }
            }

            Queue<int> queue = new();

            for (int node = 0; node < inDegree.Length; node++)
            {
                if (inDegree[node] == 0)
                {
                    queue.Enqueue(node);
                }
            }

            List<int> order = [];

            while (queue.Any())
            {
                int current = queue.Dequeue();

                order.Add(current);

                foreach (var to in adjacencyList[current])
                {
                    inDegree[to]--;

                    if (inDegree[to] == 0)
                    {
                        queue.Enqueue(to);
                    }
                }
            }

            if (order.Count != numCourses)
                return [];

            return order.ToArray();
        }

        public void Test()
        {
            int numCourses = 4;
            int[][] prerequisites = new int[][]
            {
            new int[] {1, 0},  // 0 -> 1
            new int[] {2, 0},  // 0 -> 2
            new int[] {3, 1},  // 1 -> 3
            new int[] {3, 2}   // 2 -> 3
            };

            int[] order = FindOrder(numCourses, prerequisites);

            if (order.Length == 0)
            {
                Console.WriteLine("Cycle detected! No valid order.");
            }
            else
            {
                Console.WriteLine("Valid topological order:");
                Console.WriteLine(string.Join(", ", order));
            }
        }
    }
}
