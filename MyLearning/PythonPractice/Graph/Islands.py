"""Question:
Count the number of islands in a binary grid (connected 1s).
"""

"""Notes:
Given an m x n 2D binary grid grid which represents a map of '1's (land) and '0's (water), return the number of islands.

An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically. You may assume all four edges of the grid are all surrounded by water.

Example 1:

Input: grid = [
  ["1","1","1","1","0"],
  ["1","1","0","1","0"],
  ["1","1","0","0","0"],
  ["0","0","0","0","0"]
]
Output: 1

Example 2:

Input: grid = [
  ["1","1","0","0","0"],
  ["1","1","0","0","0"],
  ["0","0","1","0","0"],
  ["0","0","0","1","1"]
]
Output: 3

 

Constraints:

    m == grid.length
    n == grid[i].length
    1 <= m, n <= 300
    grid[i][j] is '0' or '1'.


"""

from collections import deque
from typing import List, Tuple


from collections import deque

def num_islands_bfs(grid) -> int:
    rows, cols = len(grid), len(grid[0])
    islands = 0

    for r in range(rows):
        for c in range(cols):
            if grid[r][c] != "1":
                continue

            islands += 1
            q = deque([(r, c)])
            grid[r][c] = "0"

            while q:
                cr, cc = q.popleft()
                for dr, dc in [(-1,0),(1,0),(0,-1),(0,1)]:
                    nr, nc = cr + dr, cc + dc
                    if 0 <= nr < rows and 0 <= nc < cols and grid[nr][nc] == "1":
                        grid[nr][nc] = "0"
                        q.append((nr, nc))

    return islands



def num_islands_dfs(grid: List[List[str]]) -> int:
    # Same logic as BFS, but use recursion to flood-fill an island.
    rows, cols = len(grid), len(grid[0])

    def dfs(r: int, c: int) -> None:
        # Stop if out of bounds or not land.
        if r < 0 or r >= rows or c < 0 or c >= cols or grid[r][c] != "1":
            return
        # Mark this land cell as visited.
        grid[r][c] = "0"
        # Recurse in 4 directions.
        dfs(r - 1, c)
        dfs(r + 1, c)
        dfs(r, c - 1)
        dfs(r, c + 1)

    islands = 0
    for r in range(rows):
        for c in range(cols):
            # Each new unvisited land cell starts a new island traversal.
            if grid[r][c] == "1":
                islands += 1
                dfs(r, c)
    return islands
