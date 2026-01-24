"""Question:
Count the number of provinces (connected components) in an adjacency matrix of cities.
"""

"""Notes:
- is_connected is a 2D adjacency matrix.
- is_connected[i][j] == 1 means i and j are directly connected.
- Example matrix:
  [
    [1, 1, 0],
    [1, 1, 0],
    [0, 0, 1]
  ]
"""

from collections import deque
from typing import List


def count_provinces_dfs(is_connected: List[List[int]]) -> int:
    n = len(is_connected)
    visited = [False] * n

    def dfs(node: int) -> None:
        visited[node] = True
        for neighbor in range(n):
            if is_connected[node][neighbor] == 1 and not visited[neighbor]:
                dfs(neighbor)

    provinces = 0
    for node in range(n):
        if not visited[node]:
            dfs(node)
            provinces += 1
    return provinces


def count_provinces_bfs(is_connected: List[List[int]]) -> int:
    n = len(is_connected)
    visited = [False] * n
    provinces = 0
    for node in range(n):
        if visited[node]:
            continue
        provinces += 1
        queue: deque[int] = deque([node])
        visited[node] = True
        while queue:
            current = queue.popleft()
            for neighbor in range(n):
                if is_connected[current][neighbor] == 1 and not visited[neighbor]:
                    visited[neighbor] = True
                    queue.append(neighbor)
    return provinces
