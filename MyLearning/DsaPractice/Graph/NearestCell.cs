using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsaPractice.Graph
{
    /*
     * Given a binary grid of n*m. Find the distance of the nearest 1 in the grid for each cell.
     * The distance is calculated as |i1 - i2| + |j1 - j2|, where i1, j1 are the row number and column number
     * of the current cell, and i2, j2 are the row number and column number of the nearest cell having value 1.
     * There should be at least one 1 in the grid.
     * 
     * Input: 
     *   grid = [[0,1,1,0],   
     *           [1,1,0,0], 
     *           [0,0,1,1]]
     * Output: 
     *   [[1,0,0,1], 
     *    [0,0,1,1], 
     *    [1,1,0,0]]
     * 
     */
    internal class NearestCell
    {
        public void nearest(List<List<int>> grid)
        {
            /*
              i1 - i2 => row number of current cell - row no of nearest cell having 1
              j1 - j2 => column number of current cell - column no of nearest cell having 1

              BFS is done from multiple sources simultaneously
              This approach is called Multi-source BFS, and it's optimal for problems like:
              Distance to the nearest 1, Rotting oranges, Fire spread time, etc.
            */

            Queue<(int row, int col, int distance)> queue = new();

            for (int row = 0; row < grid.Count; row++)
            {
                for (int col = 0; col < grid[row].Count; col++)
                {
                    if (grid[row][col] == 1)
                    {
                        grid[row][col] = 0;
                        queue.Enqueue((row, col, 0));
                    }
                    else
                        grid[row][col] = -1;
                }
            }

            BFS(grid, queue);
        }

        private void BFS(List<List<int>> grid, Queue<(int row, int col, int distance)> nodes)
        {
            int rows = grid.Count;
            int cols = grid[0].Count;

            int[] topDown = [-1, 1, 0, 0];
            int[] leftRight = [0, 0, -1, 1];

            while(nodes.Count > 0)
            {
                var (row, col, distance) = nodes.Dequeue();

                for (int i = 0; i < 4;  i++)
                {
                    int newRow = row + topDown[i];
                    int newCol = col + leftRight[i];

                    if (newRow >=0 && newRow < rows && newCol >=0 && newCol < cols && grid[newRow][newCol] == -1)
                    {
                        grid[newRow][newCol] = distance + 1;
                        nodes.Enqueue((newRow, newCol, distance + 1));
                    }
                }
            }
        }

        public void Test()
        {
            List<List<int>> grid = [[0, 1, 1, 0], [1, 1, 0, 0], [0, 0, 1, 1]];
            nearest(grid);

            for (int row = 0; row < grid.Count; row++)
            {
                for (int col = 0; col < grid[row].Count; col++)
                {
                    Console.Write(grid[row][col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
