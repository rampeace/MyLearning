using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DsaPractice.Graph
{
    /* Provides functionality to find the shortest path in a Directed Acyclic Graph (DAG).
    *
    * Given a Directed Acyclic Graph of V vertices from 0 to n-1 and a 2D integer array edges[ ][ ] of length E,
    * where there is a directed edge from edge[i][0] to edge[i][1] with a distance of edge[i][2] for all i.
    *
    * Find the shortest path from src(0) vertex to all the vertices and if it is impossible to reach any vertex,
    * then return -1 for that vertex.
    *
    * Example:
    * Input: V = 4, E = 2, edges = [[0,1,2], [0,2,1]]
    * Output: [0, 2, 1, -1]
    * Explanation: Shortest path from 0 to 1 is 0->1 with edge weight 2.
    * Shortest path from 0 to 2 is 0->2 with edge weight 1.
    * There is no way we can reach 3, so it's -1 for 3.
    * 
    * Algorithm:
    * Keep track of best distance of each node as we explore the graph
    * A(best distance x) -> B(best distance y) -> C(best distance z)
    *Relaxation is the process of updating our best guess for a node’s shortest distance IF we find a better (shorter) way to reach it
    *
    **/
    internal class ShortestPathDAG
    {
        //public int[] ShortestPath(int V, int E, int[][] edges)
        //{
        //    // 
        //    // 
        //    // 
        //}
    }
}
