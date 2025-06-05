using System;
using System.Collections.Generic;
using System.Text;

namespace DsaPractice.Graph
{
    /*   1    2    3
     * A -> B -> C -> A   
     * 
     * Edges -> (A, B, 1), (A, C, 2), (C, A, 3)
     * 
     * 
     * Dijkstra:
     * Enqueue A (Weight 1) -> Dequeue A -> Enqueue B (0 + 1), C(0 + 2) ->  Dequeue B Nothing -> Dequeue C -> Enqueue A
     * 
     */
    internal class BellmanFordAlgorithm
    {

    }
}
