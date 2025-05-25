using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsaPractice.Graph
{
    internal class Islands
    {
        /*
         * https://leetcode.com/problems/number-of-islands/
         * 
         *  Given an m x n 2D binary grid grid which represents a map of '1's (land) and '0's (water), return the number of islands.
            An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically.
            You may assume all four edges of the grid are all surrounded by water.
         *                     
         * Implicit Graph (Edges are move up, move down, move right, move left)
         *  -Am I given actual node connections?	✅ Explicit
            -Do I have to use rules (like movement) to find connections?	✅ Implicit
            -Is the input a grid, maze, or board?	✅ Implicit
         * 
         *                    0   1   2   3   4  
         *                  ----------------------
                          0 ["1","1","0","1","0"],
                          1 ["1","1","0","1","0"],
                          2 ["1","1","0","0","0"],
                          3 ["0","0","0","0","0"]

           BFS/DFS:  
            0 -> Connected: 0, 1, 2, 3
            0 -> (0, 1, 2, 3) All visited
            1 -> (1, 2, 3) All Visited
            2 -> (0, 1) All visited
            3 -> No connections
                    
         * Output: 1        
                              0   1   2   3   4
                            ---------------------
                          0 ["1","1","0","0","0"],
                          1 ["1","1","0","0","0"],
                          2 ["0","0","1","0","0"],
                          3 ["0","0","0","1","1"]

           BFS/DFS:  
            0 -> 
            0 -> Connected: 1
                    
          Output: 3
         * 
         * */

        public int NumIslands(char[][] grid)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;

            int islands = 0;

            for (int row = 0; row < grid.Length; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (grid[row][col] == '1')
                    {
                        BFS(grid, row, col, rows, cols);
                        islands++;
                    }
                }
            }
            return islands;
        }

        private void BFS(char[][] grid, int row, int col, int rows, int cols)
        {
            Queue<(int row, int col)> queue = new();

            queue.Enqueue((row, col));
            grid[row][col] = '0';

            // top, down right, left
            int[] topDown = [-1, 1, 0, 0];
            int[] rightLeft = [0, 0, 1, -1];

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                for (int i = 0; i < 4; i++)
                {
                    int newRow = current.row + topDown[i];
                    int newCol = current.col + rightLeft[i];

                    if (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < cols)
                    {
                        if (grid[newRow][newCol] == '1' && grid[newRow][newCol] == '1')
                        {
                            queue.Enqueue((newRow, newCol));
                            grid[newRow][newCol] = '0';
                        }
                    }
                }
            }
        }

        public void Test()
        {
            char[][] grid = [
                ['1','1','0','0','0'],
                ['1','1','0','0','0'],
                ['0','0','1','0','0'],
                ['0','0','0','1','1']
            ];

            //int islands = NumIslands(grid);
            int islands = NumIslandsDFS(grid);
            Console.WriteLine(islands);
        }

        public int NumIslandsDFS(char[][] grid)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;

            int islands = 0;

            for (int row = 0; row < grid.Length; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (grid[row][col] == '1')
                    {
                        DFS(grid, row, col, rows, cols);
                        islands++;
                    }
                }
            }
            return islands;
        }

        private void DFS(char[][] grid, int row, int col, int rows, int cols)
        {
            if (row < 0 || row >= rows || col < 0 || col >= cols || grid[row][col] == '0')
                return;

            grid[row][col] = '0'; // mark as visited 

            // top, down, right, left
            int[] topDown = [-1, 1, 0, 0];
            int[] rightLeft = [0, 0, 1, -1];

            for (int i = 0; i < 4; i++)
            {
                int newRow = row + topDown[i];
                int newCol = col + rightLeft[i];

                DFS(grid, newRow, newCol, rows, cols);
            }
        }
    }
}
