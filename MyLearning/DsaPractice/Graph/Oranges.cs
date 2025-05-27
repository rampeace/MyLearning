using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DsaPractice.Graph
{
    internal class Oranges
    {
        /*
         * https://leetcode.com/problems/rotting-oranges/description/
         *  
         *  2 1 1
         *  1 1 0
         *  0 1 1
         * 
         * 0 -> empty cell
         * 1 -> fresh orange
         * 2 -> rotten orange
         * Output: 4
         * 
         * 2 1 1
         * 0 1 1
         * 1 0 1
         * 
         * Output: -1
         * 
         */
        public int OrangesRotting(int[][] grid)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;

            Queue<(int row, int col, int minutes)> rottenOranges = new();

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (grid[row][col] == 2)
                    {
                        rottenOranges.Enqueue((row, col, 0));
                    }
                }
            }

            return BFS(grid, rottenOranges, rows, cols);
        }

        private int BFS(int[][] grid, Queue<(int row, int col, int minutes)> queue, int rows, int cols)
        {
            int[] topDown = [-1, 1, 0, 0];
            int[] leftRight = [0, 0, -1, 1];
            int level = 0;

            while (queue.Count > 0)
            {
                var (row, col, minutes) = queue.Dequeue();
                level = minutes;

                for (int i = 0; i < 4; i++)
                {
                    int newRow = topDown[i] + row;
                    int newCol = leftRight[i] + col;

                    if (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < cols && grid[newRow][newCol] == 1)
                    {
                        grid[newRow][newCol] = 2;
                        queue.Enqueue((newRow, newCol, level + 1));
                    }
                }
            }

            return grid.Any(array => array.Any(i => i == 1)) ? -1 : level;
        }

        public void Test()
        {
            //   int[][] grid = [[2, 1, 1], [0, 1, 1], [1, 0, 1]];

            int[][] grid = [[2, 1, 1], [1, 1, 0], [0, 1, 1]];

            int minutes = OrangesRotting(grid);

            Console.WriteLine(minutes);
        }
    }
}
