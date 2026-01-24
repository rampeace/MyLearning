from collections import deque
from typing import List, Tuple


def num_enclaves_dfs(grid: List[List[int]]) -> int:
    rows, cols = len(grid), len(grid[0])

    def dfs(r: int, c: int) -> None:
        if r < 0 or r >= rows or c < 0 or c >= cols or grid[r][c] == 0:
            return
        grid[r][c] = 0
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

    return sum(cell == 1 for row in grid for cell in row)


def num_enclaves_bfs(grid: List[List[int]]) -> int:
    rows, cols = len(grid), len(grid[0])
    queue: deque[Tuple[int, int]] = deque()

    for r in range(rows):
        for c in [0, cols - 1]:
            if grid[r][c] == 1:
                grid[r][c] = 0
                queue.append((r, c))
    for c in range(cols):
        for r in [0, rows - 1]:
            if grid[r][c] == 1:
                grid[r][c] = 0
                queue.append((r, c))

    while queue:
        r, c = queue.popleft()
        for dr, dc in [(-1, 0), (1, 0), (0, -1), (0, 1)]:
            nr, nc = r + dr, c + dc
            if 0 <= nr < rows and 0 <= nc < cols and grid[nr][nc] == 1:
                grid[nr][nc] = 0
                queue.append((nr, nc))

    return sum(cell == 1 for row in grid for cell in row)
