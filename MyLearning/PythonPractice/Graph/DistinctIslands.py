from typing import List, Set, Tuple


def count_distinct_islands(grid: List[List[int]]) -> int:
    rows, cols = len(grid), len(grid[0])
    visited: Set[Tuple[int, int]] = set()
    shapes: Set[Tuple[Tuple[int, int], ...]] = set()

    def dfs(r: int, c: int, base_r: int, base_c: int, shape: List[Tuple[int, int]]) -> None:
        visited.add((r, c))
        shape.append((r - base_r, c - base_c))
        for dr, dc in [(-1, 0), (1, 0), (0, -1), (0, 1)]:
            nr, nc = r + dr, c + dc
            if 0 <= nr < rows and 0 <= nc < cols and grid[nr][nc] == 1 and (nr, nc) not in visited:
                dfs(nr, nc, base_r, base_c, shape)

    for r in range(rows):
        for c in range(cols):
            if grid[r][c] == 1 and (r, c) not in visited:
                shape: List[Tuple[int, int]] = []
                dfs(r, c, r, c, shape)
                shapes.add(tuple(shape))
    return len(shapes)
