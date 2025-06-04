using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Numerics;
using System.Text;

namespace DsaPractice.Graph
{
    /// <summary>
    /// https://www.geeksforgeeks.org/problems/path-with-minimum-effort/1
    /// 
    /// You are a hiker preparing for an upcoming hike. You are given heights[][], a 2D array of size rows x columns, 
    /// where heights[row][col] represents the height of cell (row, col). You are situated in the top-left cell, (0, 0), 
    /// and you hope to travel to the bottom-right cell, (rows-1, columns-1) (i.e., 0-indexed). You can move up, down, 
    /// left, or right, and you wish to find the route with minimum effort.
    /// 
    /// Note: A route's effort is the maximum absolute difference in heights between two consecutive cells of the route.
    /// 
    /// Example 1:
    /// Input:
    /// row = 3
    /// columns = 3 
    /// heights = [[1,2,2],
    ///            [3,8,2],
    ///            [5,3,5]]
    ///            
    /// Output: 2
    /// Explanation: 
    /// The route 1->3->5->3->5 has a maximum absolute difference of 2 in consecutive cells. 
    /// This is better than the route 1->2->2->2->5, where the maximum absolute difference is 3.
    /// You want to find the minimum effort path from (0,0) to (rows-1, columns-1), where effort is 
    /// defined as the maximum absolute difference in heights between consecutive cells on that path.
    /// Key point: You want the path with the minimum maximum step difference, which is a typical “minimum of the maximum” 
    /// problem—often solved via Dijkstra’s algorithm, but with the twist of comparing the maximum differences.
    /// </summary>
    internal class PathWithMinimumEffort
    {
        public int MinimumEffort(int rows, int columns, List<List<int>> heights)
        {
            (int row, int col) source = (0, 0);
            (int row, int col) destination = (rows - 1, columns - 1);

            int[][] efforts = [..Enumerable.Range(0, rows)
                .Select(row => Enumerable.Range(0, columns).Select(col => row == 0 && col == 0 ? 0 : int.MaxValue).ToArray())];


            PriorityQueue<(int row, int col), int> priorityQueue = new();
            priorityQueue.Enqueue(source, 0);

            while (priorityQueue.Count > 0)
            {
                priorityQueue.TryDequeue(out var current, out var distance);
                var (row, col) = current;

                if (current == destination)
                {
                    return distance;
                }

                (int dr, int dc)[] directions = [(-1, 0), (1, 0), (0, -1), (0, 1)];

                foreach (var (dr, dc) in directions)
                {
                    int newRow = row + dr;
                    int newCol = col + dc;

                    if (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < columns)
                    {
                        int newEffort = Math.Abs(heights[row][col] - heights[newRow][newCol]);

                        // get the max distance so far in this path
                        int maxEffort = Math.Max(newEffort, distance);

                        // get the min distance for that node
                        if (maxEffort < efforts[newRow][newCol])
                        {
                            efforts[newRow][newCol] = maxEffort;
                            priorityQueue.Enqueue((newRow, newCol), maxEffort);
                        }
                    }
                }
            }

            return 0;
        }

        public void Test()
        {
            int rows = 3;
            int columns = 3;

            List<List<int>> heights = [[1, 2, 2], [3, 8, 2], [5, 3, 5]];
            //List<List<int>> heights = [[7, 7], [7, 7]];

            int minimumEffort = MinimumEffort(rows, columns, heights);

            Console.WriteLine(minimumEffort);
        }
    }

}
