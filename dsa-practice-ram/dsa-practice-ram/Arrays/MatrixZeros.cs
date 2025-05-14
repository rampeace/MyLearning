namespace dsa_practice_ram.Arrays
{
    internal class MatrixZeros
    {
        public void SetMatrixZerosBetterSolution()
        {
            // Mark entire row and column as zeros if there is any zero
            /*
             * 0 -> No mark, 1 -> mark 
             * 
             *   0 1 1 0
             * ---------
             0 | 1 1 1 1
             1 | 1 0 1 1
             1 | 1 1 0 1
             1 | 1 0 0 1

            Output:
                1 0 0 1
                0 0 0 0
                0 0 0 0
                0 0 0 0
             */

            int[,] matrix = new int[,]
            {
                { 1, 1, 1, 1 },
                { 1, 0, 1, 1 },
                { 1, 1, 0, 1 },
                { 1, 0, 0, 1 }
            };

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int[] markedRows = new int[rows];
            int[] markedCols = new int[cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row, col] == 0)
                    {
                        markedRows[row] = 1;
                        markedCols[col] = 1;
                    }
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (markedRows[row] == 1 || markedCols[col] == 1)
                    {
                        matrix[row, col] = 0;
                    }
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
        
        public void SetMatrixZerosOptimal()
        {
            /* Mark entire row and column as zeros if there is any zero
             * 
             *   0|0 0 1  => It already serves as its own row marker, too.
             *  ---------
             1 | 1 1 1 1
             0 | 1 0 1 1
             0 | 1 1 0 1
             0 | 0 1 1 1

            After partially filled:

                 0|0 0 1
               ---------
             1 | * * * *
             0 | * 0 0 0
             0 | * 0 0 0
             0 | * 0 0 0

            Output:

                0 0 0 1
                0 0 0 0
                0 0 0 0
                0 0 0 0
             */

            int[,] matrix = new int[,]
            {
                { 1, 1, 1, 1 },
                { 1, 0, 1, 1 },
                { 1, 1, 0, 1 },
                { 0, 1, 1, 1 }
            };

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int Col0 = 1;

            // Use the first row and first column to mark
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row, col] == 0)
                    {
                        matrix[row, 0] = 0;

                        if (col == 0)
                            Col0 = 0;
                        else
                            matrix[0, col] = 0;
                    }
                }
            }

            // Update the matrix based on the markings except the first row and first column
            for (int row = 1; row < rows; row++)
            {
                for (int col = 1; col < cols; col++)
                {
                    if (matrix[row, col] != 0)
                    {
                        if (matrix[row, 0] == 0 || matrix[0, col] == 0)
                        {
                            matrix[row, col] = 0;
                        }
                    }
                }
            }

            // If the row is marked as 1 there is no need to change anything on the marked row
            if (matrix[0, 0] == 0)
            {
                for (int col = 0; col < cols; col++)
                {
                    matrix[0, col] = 0;
                }
            }

            // Update the first column based on the first element(actually saved) of the first column
            if (Col0 == 0)
            {
                for (int row = 0; row < rows; row++)
                {
                    matrix[row, 0] = 0;
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
