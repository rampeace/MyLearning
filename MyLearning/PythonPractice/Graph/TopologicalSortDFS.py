"""Question:
Return a topological ordering of a DAG using DFS.
"""

"""Notes:
- edges is a 2D list: [[from, to], ...].
- DFS finishes nodes, then reverse finish order.
- Example edges:
  [
    [2, 3],
    [3, 1],
    [4, 0],
    [4, 1],
    [5, 0],
    [5, 2]
  ]
"""

from typing import List


def topological_sort_dfs(v: int, edges: List[List[int]]) -> List[int]:
    adj = [[] for _ in range(v)]
    for frm, to in edges:
        adj[frm].append(to)

    visited = [False] * v
    stack: List[int] = []

    def dfs(node: int) -> None:
        visited[node] = True
        for to in adj[node]:
            if not visited[to]:
                dfs(to)
        stack.append(node)

    for node in range(v):
        if not visited[node]:
            dfs(node)
    stack.reverse()
    return stack
