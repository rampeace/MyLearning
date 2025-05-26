using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsaPractice.Graph
{
    /*
     * https://leetcode.com/problems/number-of-enclaves/description/
     * 
     *  You are given an m x n binary matrix grid, where 0 represents a sea cell and 1 represents a land cell.
        A move consists of walking from one land cell to another adjacent (4-directionally) land cell or walking
        off the boundary of the grid.
       Return the number of land cells in grid for which we cannot walk off the boundary of the grid in any number of moves.
     *      
             0 0 0 0 
             1 0 1 0
             0 1 1 0
             0 0 0 0

    If a problem can be reduced to "things connected in some way", it's a strong sign it's a graph problem.
     * */
    internal class Enclaves
    {
        public int NumEnclaves(int[][] grid)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;

            for (int row = 0; row < rows; row++)
            {
                DFS(grid, row, 0, rows, cols);
                DFS(grid, row, cols - 1, rows, cols);
            }

            for (int col = 0; col < cols; col++)
            {
                DFS(grid, 0, col, rows, cols);
                DFS(grid, rows - 1, col, rows, cols);
            }

            int enclaves = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (grid[i][j] == 1)
                        enclaves++;
                }
            }
            return enclaves;
        }

        private void DFS(int[][] grid, int row, int col, int rows, int cols)
        {
            if (row < 0 || row >= rows || col < 0 || col >= cols || grid[row][col] == 0)
                return;

            grid[row][col] = 0;

            DFS(grid, row - 1, col, rows, cols);
            DFS(grid, row + 1, col, rows, cols);
            DFS(grid, row, col - 1, rows, cols);
            DFS(grid, row, col + 1, rows, cols);
        }

        public void Test()
        {
            int[][] grid = [
                [0, 0, 0, 0],
                [1, 0, 1, 0],
                [0, 1, 1, 0],
                [0, 0, 0, 0]
            ];

            //int  enclaves = NumEnclaves(grid);
            int enclaves = NumEnclavesBFS(grid);

            Console.WriteLine(enclaves);
        }

        public int NumEnclavesBFS(int[][] grid)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;

            for (int row = 0; row < rows; row++)
            {
                if (grid[row][0] == 1)
                    BFS(grid, row, 0, rows, cols);

                if (grid[row][cols - 1] == 1)
                    BFS(grid, row, cols - 1, rows, cols);
            }

            for (int col = 0; col < cols; col++)
            {
                if (grid[0][col] == 1)
                    BFS(grid, 0, col, rows, cols);

                if (grid[rows - 1][col] == 1)
                    BFS(grid, rows - 1, col, rows, cols);
            }

            int enclaves = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (grid[i][j] == 1)
                        enclaves++;
                }
            }
            return enclaves;
        }

        private void BFS(int[][] grid, int row, int col, int rows, int cols)
        {
            Queue<(int row, int col)> queue = new();
            queue.Enqueue((row, col));
            grid[row][col] = 0;

            int[] topDown = [-1, 1, 0, 0];
            int[] leftRight = [0, 0, -1, 1];

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                for (int i = 0; i < 4; i++)
                {
                    int newRow = topDown[i] + current.row;
                    int newCol = leftRight[i] + current.col;

                    if (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < cols && grid[newRow][newCol] == 1)
                    {
                        grid[newRow][newCol] = 0;
                        queue.Enqueue((newRow, newCol));
                    }
                }
            }
        }
    }
}
