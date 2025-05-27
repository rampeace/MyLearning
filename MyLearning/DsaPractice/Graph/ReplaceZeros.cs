using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DsaPractice.Graph
{
    internal class ReplaceZeros
    {
        /*
         * https://www.geeksforgeeks.org/problems/replace-os-with-xs0052/1?
         * Problem: Replace all 'O' or a group of 'O' with 'X' that are surrounded by 'X' in a matrix.
         * A 'O' (or a set of 'O') is considered to be surrounded by 'X' if there are 'X' at locations just below,
         * just above, just left and just right of it.
         * 
         * Example:
         * Input: 
         * [
         *   ['X', 'X', 'X', 'X'],
         *   ['X', 'O', 'X', 'X'],
         *   ['X', 'O', 'O', 'X'],
         *   ['X', 'O', 'X', 'X'],
         *   ['X', 'X', 'O', 'O']
         * ]
         * Output: 
         * [
         *   ['X', 'X', 'X', 'X'],
         *   ['X', 'X', 'X', 'X'],
         *   ['X', 'X', 'X', 'X'],
         *   ['X', 'X', 'X', 'X'],
         *   ['X', 'X', 'O', 'O']
         * ]
         * Explanation: Only those 'O' that are surrounded by 'X' are changed.
         */

        public void ConvertZerosToX(List<List<char>> matrix)
        {
            int rows = matrix.Count;
            int cols = matrix[0].Count;

            HashSet<(int row, int col)> visited = new();

            for (int row = 0; row < rows; row++)
            {
                if (matrix[row][0] == 'O')
                {
                    DFS(matrix, row, 0, rows, cols, visited);
                }
                if (matrix[row][cols - 1] == 'O')
                {
                    DFS(matrix, row, cols - 1, rows, cols, visited);
                }
            }

            for (int col = 1; col < cols - 1; col++)
            {
                if (matrix[0][col] == 'O')
                {
                    DFS(matrix, 0, col, rows, cols, visited);
                }
                if (matrix[rows - 1][col] == 'O')
                {
                    DFS(matrix, rows - 1, col, rows, cols,visited);
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row][col] == 'O') 
                        matrix[row][col] = 'X';

                    if (matrix[row][col] == 'A')
                        matrix[row][col] = 'O';

                }
            }
        }

        private void DFS(List<List<char>> matrix, int row,  int col, int rows, int cols, HashSet<(int row, int col)> visited)
        {
            if (row < 0 || row >= rows || col < 0 || col >= cols || visited.Contains((row, col)) || matrix[row][col] != 'O')
                return;

            matrix[row][col] = 'A';

            visited.Add((row, col));

            int[] topDown = [-1,  1, 0, 0];
            int[] leftRight = [0, 0, -1, 1];

            for (int i=0; i< 4; i++)
            {
                int newRow = row + topDown[i];
                int newCol = col + leftRight[i];

                DFS(matrix, newRow, newCol, rows, cols, visited);   
            }
        }

        public void Test()
        {
            List<List<char>> matrix = 
                [['X', 'X', 'X', 'X'],
                ['X', 'O', 'X', 'X'],
                ['X', 'O', 'O', 'X'],
                ['X', 'O', 'X', 'X'],
                ['X', 'X', 'O', 'O']];

            ConvertZerosToX(matrix);

            for (int row = 0; row < matrix.Count; row++)
            {
                for (int col = 0; col < matrix[0].Count; col++)
                {
                    Console.Write(matrix[row][col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
