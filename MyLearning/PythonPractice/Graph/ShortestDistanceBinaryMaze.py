"""Question:
Find shortest path in a binary grid from source to destination moving in 4 directions.
"""

"""Notes:
- grid is a 2D list of 0/1.
- Move in 4 directions; 1 means passable.
- Example grid:
  [
    [1, 1, 1],
    [1, 0, 1],
    [1, 1, 1]
  ]
"""

from collections import deque
from typing import List, Set, Tuple


def shortest_distance_binary_maze(
    grid: List[List[int]],
    source: Tuple[int, int],
    destination: Tuple[int, int],
) -> int:
    rows, cols = len(grid), len(grid[0])
    sr, sc = source
    dr, dc = destination
    if grid[sr][sc] == 0 or grid[dr][dc] == 0:
        return -1
    if source == destination:
        return 0
    queue: deque[Tuple[int, int, int]] = deque([(sr, sc, 0)])
    visited: Set[Tuple[int, int]] = {(sr, sc)}
    while queue:
        r, c, dist = queue.popleft()
        for drc, dcc in [(-1, 0), (1, 0), (0, -1), (0, 1)]:
            nr, nc = r + drc, c + dcc
            if 0 <= nr < rows and 0 <= nc < cols and (nr, nc) not in visited and grid[nr][nc] == 1:
                if (nr, nc) == destination:
                    return dist + 1
                visited.add((nr, nc))
                queue.append((nr, nc, dist + 1))
    return -1
