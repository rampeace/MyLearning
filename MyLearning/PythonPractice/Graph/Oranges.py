from collections import deque
from typing import List, Tuple


def oranges_rotting(grid: List[List[int]]) -> int:
    rows, cols = len(grid), len(grid[0])
    queue: deque[Tuple[int, int, int]] = deque()
    for r in range(rows):
        for c in range(cols):
            if grid[r][c] == 2:
                queue.append((r, c, 0))

    minutes = 0
    while queue:
        r, c, minutes = queue.popleft()
        for dr, dc in [(-1, 0), (1, 0), (0, -1), (0, 1)]:
            nr, nc = r + dr, c + dc
            if 0 <= nr < rows and 0 <= nc < cols and grid[nr][nc] == 1:
                grid[nr][nc] = 2
                queue.append((nr, nc, minutes + 1))

    if any(1 in row for row in grid):
        return -1
    return minutes
