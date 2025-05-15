using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace dsa_practice_ram.Arrays
{
    internal class RotateMatrix
    {
        public void Rotate90DegreesBruteForce()
        {
            /*
             * Original Matrix:
             * 
             *       0   1   2   3
             *    ----------------
                0 |  1   2   3   4
                1 |  5   6   7   8
                2 |  9  10  11  12
                3 | 13  14  15  16

                Rotated Matrix (90 degrees clockwise):
                  13   9   5   1
                  14  10   6   2
                  15  11   7   3
                  16  12   8   4

            Pattern:

            [0, 0] -> [0, 3]        [1, 0] -> [0, 2]
            [0, 1] -> [1, 3]        [1, 1] -> [1, 2]
            [0, 2] -> [2, 3]        [1, 2] -> [2, 2]
            [0, 3] -> [3, 3]        [1, 3] -> [3, 2]

            row = col
            col = (rows - 1) - row

             */

            int[,] matrix = new int[,]
            {
                { 1,  2,  3,  4 },
                { 5,  6,  7,  8 },
                { 9, 10, 11, 12 },
                {13, 14, 15, 16 }
            };

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int[,] result = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    result[col, rows - 1 - row] = matrix[row, col];
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

        public void Rotate90DegreesOpimal()
        {
            /*
         *           0   1   2   3
             *    ----------------
                0 |  1   2   3   4
                1 |  5   6   7   8
                2 |  9  10  11  12
                3 | 13  14  15  16

                Rotated Matrix (90 degrees clockwise):
                  13   9   5   1
                  14  10   6   2
                  15  11   7   3
                  16  12   8   4

            Transpose:
                1   5   9  13  
                2   6  10  14  
                3   7  11  15  
                4   8  12  16   

            Reverse:
                13   9   5   1
                14  10   6   2
                15  11   7   3
                16  12   8   4

            Ideas to transpose:
            - The diagonals remain the same

            Swap (0,1) with (1,0) → 2 ↔ 5  
            Swap (0,2) with (2,0) → 3 ↔ 9  
            Swap (0,3) with (3,0) → 4 ↔ 13  

            Swap (1,2) with (2,1) → 7 ↔ 10  
            Swap (1,3) with (3,1) → 8 ↔ 14  

            Swap (2,3) with (3,2) → 12 ↔ 15

            Traverse Strategy:

            - Traverse only the marked areas

                 *   0    1    2     3
             *    ----------------------
                0 |  1   -2-  -3-   -4-
                1 |  5    6   -7-   -8-
                2 |  9   10   11    -12-
                3 | 13   14   15     16

            rows = 0 To < rows - 1
            cols = row + 1 To < cols 

            */

            int[,] matrix = new int[,]
            {
                { 1,  2,  3,  4 },
                { 5,  6,  7,  8 },
                { 9, 10, 11, 12 },
                {13, 14, 15, 16 }
            };

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            // Transpose
            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = row + 1; col < cols; col++)
                {
                    int temp = matrix[row, col];
                    matrix[row, col] = matrix[col, row];
                    matrix[col, row] = temp;
                }
            }

            // Reverse each row in the matrix
            for (int row = 0; row < rows; row++)
            {
                int left = 0;
                int right = cols - 1;

                while(left < right) 
                {
                    int temp = matrix[row, left];
                    matrix[row, left] = matrix[row, right];
                    matrix[row, right] = temp;

                    left++;
                    right--;
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
