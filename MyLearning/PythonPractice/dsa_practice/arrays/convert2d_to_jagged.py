"""2D to jagged array conversion."""

# C# Convert2DToJagged.ConvertToJagged

def convert_to_jagged(matrix=None):
    """Convert a 2D matrix into a jagged list of lists.

    Problem: Convert a 2D array into a jagged array (array of rows).
    Approach: Copy each row into a new list.
    Time complexity: O(r * c)
    Space complexity: O(r * c)
    """
    if matrix is None:
        matrix = [
            [1, 1, 1, 1],
            [1, 0, 1, 1],
            [1, 1, 0, 1],
            [1, 0, 0, 1],
        ]

    return [list(row) for row in matrix]
