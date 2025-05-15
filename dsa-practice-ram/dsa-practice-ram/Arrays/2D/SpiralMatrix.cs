using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace dsa_practice_ram.Arrays._2D
{
    internal class SpiralMatrix
    {
        public void PrintSpiralMatrix()
        {
            /*  
             *             left              right
             *              0   1   2   3   4   5
             *             ---------------------
             *      top 0 | 1   2   3   4   5   6
             *          1 | 20  21  22  23  24  7
             *          2 | 19  33  32  34  25  8
             *          3 | 18  31  36  35  26  9
             *          4 | 17  30  29  28  27  10
             *   bottom 5 | 16  15  14  13  12  11
             *     
             * */

            List<List<int>> spiralMatrix = new List<List<int>>
            {
                new List<int> { 1,  2,  3,  4,  5,  6 },
                new List<int> { 20, 21, 22, 23, 24, 7 },
                new List<int> { 19, 32, 33, 34, 25, 8 },
                new List<int> { 18, 31, 36, 35, 26, 9 },
                new List<int> { 17, 30, 29, 28, 27, 10 },
                new List<int> { 16, 15, 14, 13, 12, 11 }
            };

            int rows = spiralMatrix.Count;
            int cols = spiralMatrix[0].Count;

            int top = 0, bottom = rows - 1, left = 0, right = cols - 1;

            List<int> result = new();

            while (left <= right && top <= bottom)
            {
                for (int i = left; i <= right; i++)
                {
                    result.Add(spiralMatrix[top][i]);
                }

                top++;

                // This ensures that before performing a bottom-row traversal or left-column traversal, we always
                // verify the matrix is still valid.

                for (int i = top; i <= bottom; i++)
                {
                    result.Add(spiralMatrix[i][right]);
                }

                right--;

                if (top <= bottom)
                {
                    for (int i = right; i >= left; i--) // r < l
                    {
                        result.Add(spiralMatrix[bottom][i]);
                    }

                    bottom--;
                }

                if (left <= right)
                {
                    for (int i = bottom; i >= top; i--)
                    {
                        result.Add(spiralMatrix[i][left]);
                    }

                    left++;
                }
            }

            Console.WriteLine(string.Join(", ", result));
        }
    }
}
