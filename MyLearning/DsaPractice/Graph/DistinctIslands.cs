using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DsaPractice.Graph
{
    /*
     * Problem: Number of Distinct Islands
     * Source: https://www.geeksforgeeks.org/problems/number-of-distinct-islands/1
     * 
     * Description:
     * Given a boolean 2D matrix 'grid' of size n x m, find the number of distinct islands.
     * An island is a group of connected 1s (connected horizontally or vertically).
     * Two islands are considered distinct if and only if one island is not equal to another
     * (no rotation or reflection is allowed).
     * 
     * Example:
     * Input:
     * grid[][] = { {1, 1, 0, 0, 0},
     *              {1, 1, 0, 0, 0},
     *              {0, 0, 0, 1, 1},
     *              {0, 0, 0, 1, 1} }
     * Output:
     * 1
     */
    internal class DistinctIslands
    {
        public int CountDistinctIslands(List<List<int>> grid)
        {
            int rows = grid.Count;
            int cols = grid[0].Count;

            HashSet<string> shapes = new();

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    StringBuilder path = new();

                    DFS(grid, row, col, rows, cols, path, "START");

                    if (path.Length > 0)
                        shapes.Add(path.ToString());
                }
            }

            return shapes.Count;
        }

        private void DFS(List<List<int>> grid, int row, int col, int rows, int cols, StringBuilder path, string direction)
        {
            if (row < 0 || row >= rows || col < 0 || col >= cols || grid[row][col] == 0)
                return;

            grid[row][col] = 0;

            // path.Append($"{row - startRow} : {col - startCol}"); // Another approach to do this

            path.Append(direction);

            DFS(grid, row - 1, col, rows, cols, path, "UP");
            DFS(grid, row + 1, col, rows, cols, path, "DOWN");
            DFS(grid, row, col - 1, rows, cols, path, "LEFT");
            DFS(grid, row, col + 1, rows, cols, path, "RIGHT");

            path.Append('B'); // Also include back track history
        }

        public void Test()
        {
            List<List<int>> grid =
            [[ 1, 1, 0, 0, 0],
            [ 1, 1, 0, 0, 0],
            [ 0, 0, 0, 1, 1],
            [ 0, 0, 0, 1, 1]];

            int distinctIslands = CountDistinctIslands(grid);

            Console.WriteLine(distinctIslands);
        }
    }
}
