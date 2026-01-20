"""Set matrix zeros utilities."""

# C# MatrixZeros.SetMatrixZerosBetterSolution

def set_matrix_zeros_better_solution(matrix=None):
    """Set rows and columns to zero if any element is zero (marker arrays).

    Problem: For any zero in the matrix, set its entire row and column to zero.
    Approach: First pass marks rows/cols; second pass applies zeros.
    Time complexity: O(r * c)
    Space complexity: O(r + c)
    """
    if matrix is None:
        matrix = [
            [1, 1, 1, 1],
            [1, 0, 1, 1],
            [1, 1, 0, 1],
            [1, 0, 0, 1],
        ]

    rows = len(matrix)
    cols = len(matrix[0]) if rows else 0
    marked_rows = [0] * rows
    marked_cols = [0] * cols

    for row in range(rows):
        for col in range(cols):
            if matrix[row][col] == 0:
                marked_rows[row] = 1
                marked_cols[col] = 1

    for row in range(rows):
        for col in range(cols):
            if marked_rows[row] == 1 or marked_cols[col] == 1:
                matrix[row][col] = 0

    return matrix


# C# MatrixZeros.SetMatrixZerosOptimal

def set_matrix_zeros_optimal(matrix=None):
    """Set rows and columns to zero using first row/column as markers.

    Problem: For any zero in the matrix, set its entire row and column to zero.
    Approach: Use the first row/column as markers to achieve O(1) extra space.
    Time complexity: O(r * c)
    Space complexity: O(1) extra
    """
    if matrix is None:
        matrix = [
            [1, 1, 1, 1],
            [1, 0, 1, 1],
            [1, 1, 0, 1],
            [0, 1, 1, 1],
        ]

    rows = len(matrix)
    cols = len(matrix[0]) if rows else 0
    col0 = 1

    for row in range(rows):
        for col in range(cols):
            if matrix[row][col] == 0:
                matrix[row][0] = 0
                if col == 0:
                    col0 = 0
                else:
                    matrix[0][col] = 0

    for row in range(1, rows):
        for col in range(1, cols):
            if matrix[row][col] != 0:
                if matrix[row][0] == 0 or matrix[0][col] == 0:
                    matrix[row][col] = 0

    if rows and matrix[0][0] == 0:
        for col in range(cols):
            matrix[0][col] = 0

    if col0 == 0:
        for row in range(rows):
            matrix[row][0] = 0

    return matrix
