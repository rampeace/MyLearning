"""Question:
Find shortest path distances from a source in an unweighted undirected graph.
"""

"""Notes:
- adjacency is a 2D list: adj[i] = neighbors of i.
- BFS on an unweighted graph gives shortest path length.
- Example adjacency:
  [
    [1, 3],
    [0, 2],
    [1, 4],
    [0],
    [2]
  ]
"""

from collections import deque
from typing import List


def shortest_path_undirected(adjacency: List[List[int]], src: int) -> List[int]:
    n = len(adjacency)
    dist = [-1] * n
    dist[src] = 0
    queue: deque[int] = deque([src])
    while queue:
        node = queue.popleft()
        for to in adjacency[node]:
            if dist[to] == -1:
                dist[to] = dist[node] + 1
                queue.append(to)
    return dist
