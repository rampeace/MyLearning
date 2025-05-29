using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsaPractice.Graph
{
    internal class ReverseGraph
    {
        public int[][] PerformReverseGraph(int[][] graph)
        {
            List<List<int>> reversed = new();

            for (int i = 0; i < graph.Length; i++)
            {
                reversed.Add([]);
            }

            for (int from = 0; from < graph.Length; from++)
            {
                foreach (var to in graph[from])
                {
                    reversed[to].Add(from);
                }
            }

            return [.. reversed.Select(list => list.ToArray())];
        }
    }
}
