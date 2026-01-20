"""Spiral order traversal of a matrix."""

# C# SpiralMatrix.PrintSpiralMatrix

def print_spiral_matrix(spiral_matrix=None):
    """Return the elements of a matrix in spiral order.

    Problem: Traverse a matrix in spiral order.
    Approach: Maintain top/bottom/left/right boundaries and peel layers.
    Time complexity: O(r * c)
    Space complexity: O(r * c) for output
    """
    if spiral_matrix is None:
        spiral_matrix = [
            [1, 2, 3, 4, 5, 6],
            [20, 21, 22, 23, 24, 7],
            [19, 32, 33, 34, 25, 8],
            [18, 31, 36, 35, 26, 9],
            [17, 30, 29, 28, 27, 10],
            [16, 15, 14, 13, 12, 11],
        ]

    rows = len(spiral_matrix)
    cols = len(spiral_matrix[0]) if rows else 0
    top = 0
    bottom = rows - 1
    left = 0
    right = cols - 1

    result = []

    while left <= right and top <= bottom:
        for i in range(left, right + 1):
            result.append(spiral_matrix[top][i])
        top += 1

        for i in range(top, bottom + 1):
            result.append(spiral_matrix[i][right])
        right -= 1

        if top <= bottom:
            for i in range(right, left - 1, -1):
                result.append(spiral_matrix[bottom][i])
            bottom -= 1

        if left <= right:
            for i in range(bottom, top - 1, -1):
                result.append(spiral_matrix[i][left])
            left += 1

    return result
