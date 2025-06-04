using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace DsaPractice.Graph
{
    /*
         *  Given a n * m matrix grid where each element can either be 0 or 1. 
         *  You need to find the shortest distance between a given source cell to a destination cell. 
         *  The path can only be created out of a cell if its value is 1. 
         *  
         *  If the path is not possible between source cell and destination cell, then return -1.
         *  
         *  Note: You can move into an adjacent cell if that adjacent cell is filled with element 1. 
         *  Two cells are adjacent if they share a side. In other words, you can move in one of the four directions: 
         *  Up, Down, Left, and Right. The source and destination cell are based on zero-based indexing. 
         *  The destination cell should be 1.
         *  
         *  Example 1:
         *  
         *  Input:
         *  grid[][] = {{1, 1, 1, 1},
         *              {1, 1, 0, 1},
         *              {1, 1, 1, 1},
         *              {1, 1, 0, 0},
         *              {1, 0, 0, 1}}
         *  source = {0, 1}
         *  destination = {2, 2}
         *  Output:
         *  3
         *  Explanation:
         *  1  -1-  1   1
         *  1  -1-  0   1
         *  1  -1- -1-  1
         *  1   1   0   0
         *  1   0   0   1
         *  
         *  The marked (-1-) part in the matrix denotes the 
         *  shortest path from source to destination cell.
         */

    internal class ShortestDistanceBinaryMaze
    {
        public int ShortestPath(List<List<int>> grid, (int row, int col) source, (int row, int col) destination)
        {
            if (grid[source.row][source.col] == 0 || grid[destination.row][destination.col] == 0)
                return -1;

            if (source == destination)
                return 0;

            int nodes = grid.Count;
            int rows = nodes;
            int cols = grid[0].Count;

            HashSet<(int row, int col)> seen = [];
            Queue<(int row, int col, int level)> queue = new();

            queue.Enqueue((source.row, source.col, 0));
            seen.Add(source);

            while (queue.Count > 0)
            {
                var (row, col, level) = queue.Dequeue();

                int[] topDown = [-1, 1, 0, 0];
                int[] leftRight = [0, 0, -1, 1];

                for (int i = 0; i < 4; i++)
                {
                    int newRow = row + topDown[i];
                    int newCol = col + leftRight[i];

                    if (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < cols && !seen.Contains((newRow, newCol)) && grid[newRow][newCol] == 1)
                    {
                        seen.Add((newRow, newCol));

                        if ((newRow, newCol) == destination)
                            return level + 1;

                        queue.Enqueue((newRow, newCol, level + 1));
                    }
                }
            }

            return -1;            
        }

        public void Test()
        {
            List<List<int>> grid = 
                [[1, 1, 1, 1],
                [1, 1, 0, 1],
                [1, 1, 1, 1],
                [1, 1, 0, 0],
                [1, 0, 0, 1]];

            int shortestPath = ShortestPath(grid, (0, 1), (2, 2));

            Console.WriteLine(shortestPath);
        }
    }
}
