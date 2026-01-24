from typing import List


def replace_zeros_with_x(matrix: List[List[str]]) -> None:
    rows, cols = len(matrix), len(matrix[0])

    def dfs(r: int, c: int) -> None:
        if r < 0 or r >= rows or c < 0 or c >= cols or matrix[r][c] != "O":
            return
        matrix[r][c] = "A"
        dfs(r - 1, c)
        dfs(r + 1, c)
        dfs(r, c - 1)
        dfs(r, c + 1)

    for r in range(rows):
        dfs(r, 0)
        dfs(r, cols - 1)
    for c in range(cols):
        dfs(0, c)
        dfs(rows - 1, c)

    for r in range(rows):
        for c in range(cols):
            if matrix[r][c] == "O":
                matrix[r][c] = "X"
            elif matrix[r][c] == "A":
                matrix[r][c] = "O"
