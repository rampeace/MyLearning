"""Question:
Find shortest paths from a source in a weighted DAG; unreachable nodes are -1.
"""

"""Notes:
- edges is a 2D list: [[from, to, weight], ...].
- Topological order ensures each edge is relaxed once.
- Example edges:
  [
    [0, 1, 2],
    [0, 2, 1],
    [1, 3, 3]
  ]
"""

from typing import List, Tuple


def shortest_path_dag(
    n: int, edges: List[Tuple[int, int, int]], src: int = 0
) -> List[int]:
    adj: List[List[Tuple[int, int]]] = [[] for _ in range(n)]
    for frm, to, weight in edges:
        adj[frm].append((to, weight))

    visited = [False] * n
    order: List[int] = []

    def dfs(node: int) -> None:
        visited[node] = True
        for to, _ in adj[node]:
            if not visited[to]:
                dfs(to)
        order.append(node)

    for node in range(n):
        if not visited[node]:
            dfs(node)

    order.reverse()
    dist = [float("inf")] * n
    dist[src] = 0
    for node in order:
        if dist[node] == float("inf"):
            continue
        for to, weight in adj[node]:
            new_dist = dist[node] + weight
            if new_dist < dist[to]:
                dist[to] = new_dist
    return [int(d) if d != float("inf") else -1 for d in dist]
