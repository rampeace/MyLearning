using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dsa_practice_ram.Arrays
{
    internal class Convert2DToJagged
    {
        public void ConvertToJagged()
        {
            int[,] matrix = new int[,]
            {
                { 1, 1, 1, 1 },
                { 1, 0, 1, 1 },
                { 1, 1, 0, 1 },
                { 1, 0, 0, 1 }
            };

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int[][] jagged = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                int[] array = new int[cols];

                for (int col = 0; col < cols; col++)
                {
                    array[col] = matrix[row, col];                    
                }
                jagged[row] = array;
            }

            for (int i = 0; i < jagged.Length; i++)
            {
                for (int j = 0; j < jagged[i].Length; j++)
                {
                    Console.Write(jagged[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
