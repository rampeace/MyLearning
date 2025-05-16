using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsaPractice.Arrays
{
    internal class Convert2DTo1D
    {
        public void Convert2DArrayTo1D()
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

            int[] result = new int[matrix.Length];
            int index = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    result[index] = matrix[row, col];
                    index++;
                }
            }

            Console.WriteLine(string.Join(", ", result));
        }
        public void Convert1DArrayTo2D()
        {
            int[] flatArray = new int[]
            {
                1, 1, 1, 1,
                1, 0, 1, 1,
                1, 1, 0, 1,
                1, 0, 0, 1
            };

            int rows = 4;
            int cols = 4;
            int index = 0;

            int[,] result = new int[rows, cols];
            
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    result[row, col] = flatArray[index];
                    index++;
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(result[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
