"""Question:
For each cell in a binary grid, compute distance to the nearest cell containing 1.
"""

"""Notes:
- grid is a 2D list of 0/1.
- Multi-source BFS starts from all cells with 1.
- Example grid:
  [
    [0, 1, 1, 0],
    [1, 1, 0, 0],
    [0, 0, 1, 1]
  ]
"""

from collections import deque
from typing import List, Tuple


def nearest_cell_distance(grid: List[List[int]]) -> List[List[int]]:
    rows, cols = len(grid), len(grid[0])
    dist = [[-1] * cols for _ in range(rows)]
    queue: deque[Tuple[int, int]] = deque()
    for r in range(rows):
        for c in range(cols):
            if grid[r][c] == 1:
                dist[r][c] = 0
                queue.append((r, c))
    while queue:
        r, c = queue.popleft()
        for dr, dc in [(-1, 0), (1, 0), (0, -1), (0, 1)]:
            nr, nc = r + dr, c + dc
            if 0 <= nr < rows and 0 <= nc < cols and dist[nr][nc] == -1:
                dist[nr][nc] = dist[r][c] + 1
                queue.append((nr, nc))
    return dist
