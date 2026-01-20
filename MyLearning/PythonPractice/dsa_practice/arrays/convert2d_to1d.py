"""2D/1D array conversions."""

# C# Convert2DTo1D.Convert2DArrayTo1D

def convert2d_array_to1d(matrix=None):
    """Flatten a 2D matrix into a 1D list in row-major order.

    Problem: Convert a 2D array into a 1D array.
    Approach: Traverse rows and columns and append to result.
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

    result = []
    for row in matrix:
        for value in row:
            result.append(value)

    return result


# C# Convert2DTo1D.Convert1DArrayTo2D

def convert1d_array_to2d(flat_array=None, rows=4, cols=4):
    """Convert a 1D list into a 2D matrix in row-major order.

    Problem: Convert a 1D array into a 2D array with given dimensions.
    Approach: Fill rows and columns from the flat list.
    Time complexity: O(r * c)
    Space complexity: O(r * c)
    """
    if flat_array is None:
        flat_array = [
            1, 1, 1, 1,
            1, 0, 1, 1,
            1, 1, 0, 1,
            1, 0, 0, 1,
        ]

    if len(flat_array) < rows * cols:
        raise IndexError("flat_array is too short for the given dimensions")

    result = [[0 for _ in range(cols)] for _ in range(rows)]
    index = 0

    for row in range(rows):
        for col in range(cols):
            result[row][col] = flat_array[index]
            index += 1

    return result
