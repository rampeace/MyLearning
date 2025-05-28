using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsaPractice.Graph
{
    internal class CountProvinces
    {
        /*
         * https://leetcode.com/problems/number-of-provinces/
         * There are n cities. Some of them are connected, while some are not. If city a is connected directly with city b,
         * and city b is connected directly with city c, then city a is connected indirectly with city c.
         * 
         * A province is a group of directly or indirectly connected cities and no other cities outside of the group.
         * You are given an n x n matrix isConnected where isConnected[i][j] = 1 if the ith city and the jth city are directly
         * connected, and isConnected[i][j] = 0 otherwise.
         * Return the total number of provinces.
         *  
         *      0  1  2
         *     ---------
             0 [1, 1, 0],
             1 [1, 1, 0],
             2 [0, 0, 1]
           
         * 
         * For all cities -> 0, 1, 2 check if all connections
         * 0 -> 0 (visited: 0)
         * 0 -> 1 (visited: 1)
         * 1 -> All visited. Loop stops
         * 
         * 1 -> Already visited. No BFS
         * 
         * 2 -> 2 (visited: 2)
         * 2 -> Nothing        
         * 
         * 
         *  DFS only explores the connected component starting from the current node.
            So it won't reach unconnected nodes — and that’s exactly what we want!
         * 
         * */

        public int FindCircleNum(int[][] isConnected)
        {
            bool[] visited = new bool[isConnected.Length];
            int provinces = 0;

            for (int i = 0; i < isConnected.Length; i++)
            {
                if (!visited[i])
                {
                    DFS(isConnected, visited, i);
                    provinces++;
                }
            }
            return provinces;
        }

        private void DFS(int[][] isConnected, bool[] visited, int i)
        {
            visited[i] = true;

            for (int j = 0; j < isConnected.Length; j++)
            {
                if (isConnected[i][j] == 1 && !visited[j])
                {
                    DFS(isConnected, visited, j);
                }
            }
        }

        public void Test()
        {
            int[][] isConnected = [[1, 1, 0], [1, 1, 0], [0, 0, 1]];
          //  int provinces = FindCircleNum(isConnected);
            int provinces = FindCircleNumBFS(isConnected);
            Console.WriteLine(provinces);
        }

        public int FindCircleNumBFS(int[][] isConnected)
        {
            bool[] visited = new bool[isConnected.Length];
            int provinces = 0;

            for (int i = 0; i < isConnected.Length; i++)
            {
                if (!visited[i])
                {
                    BFS(isConnected, visited, i);
                    provinces++;
                }
            }
            return provinces;
        }

        private void BFS(int[][] isConnected, bool[] visited, int i)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(i);
            visited[i] = true;

            while(queue.Count > 0 )
            {
                int current = queue.Dequeue();

                for (int j = 0; j < isConnected.Length; j++)
                {
                    if (isConnected[current][j] == 1 && !visited[j])
                    {
                        queue.Enqueue(j);
                        visited[j] = true;
                    }
                }
            }
        }
    }
}
