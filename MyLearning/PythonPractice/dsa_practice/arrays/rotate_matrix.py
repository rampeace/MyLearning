"""Rotate a matrix by 90 degrees."""

# C# RotateMatrix.Rotate90DegreesBruteForce

def rotate_90_degrees_brute_force(matrix=None):
    """Return a new matrix rotated 90 degrees clockwise.

    Problem: Rotate a matrix 90 degrees clockwise.
    Approach: Create a new matrix and map (row, col) to (col, n-1-row).
    Time complexity: O(n^2)
    Space complexity: O(n^2)
    """
    if matrix is None:
        matrix = [
            [1, 2, 3, 4],
            [5, 6, 7, 8],
            [9, 10, 11, 12],
            [13, 14, 15, 16],
        ]

    rows = len(matrix)
    cols = len(matrix[0]) if rows else 0
    result = [[0 for _ in range(cols)] for _ in range(rows)]

    for row in range(rows):
        for col in range(cols):
            result[col][rows - 1 - row] = matrix[row][col]

    return result


# C# RotateMatrix.Rotate90DegreesOpimal

def rotate_90_degrees_opimal(matrix=None):
    """Rotate a square matrix 90 degrees clockwise in-place.

    Problem: Rotate a square matrix 90 degrees clockwise.
    Approach: Transpose the matrix, then reverse each row.
    Time complexity: O(n^2)
    Space complexity: O(1) extra
    """
    if matrix is None:
        matrix = [
            [1, 2, 3, 4],
            [5, 6, 7, 8],
            [9, 10, 11, 12],
            [13, 14, 15, 16],
        ]

    rows = len(matrix)
    cols = len(matrix[0]) if rows else 0

    for row in range(rows - 1):
        for col in range(row + 1, cols):
            matrix[row][col], matrix[col][row] = matrix[col][row], matrix[row][col]

    for row in range(rows):
        left = 0
        right = cols - 1
        while left < right:
            matrix[row][left], matrix[row][right] = matrix[row][right], matrix[row][left]
            left += 1
            right -= 1

    return matrix
