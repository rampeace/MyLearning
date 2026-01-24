"""Question:
Compute the minimum spanning tree total weight and parent array using Prim's algorithm.
"""

"""Notes:
- edges is a 1D list of (from, to, weight).
- Build adjacency list for an undirected graph.
- Example edges: [(0, 1, 2), (0, 3, 6), (1, 2, 3)].
"""

import heapq
from typing import List, Tuple


def minimum_spanning_tree_prim(
    n: int, edges: List[Tuple[int, int, int]]
) -> Tuple[int, List[int]]:
    adj: List[List[Tuple[int, int]]] = [[] for _ in range(n)]
    for frm, to, weight in edges:
        adj[frm].append((to, weight))
        adj[to].append((frm, weight))

    parents = [-1] * n
    total_weight = 0
    heap: List[Tuple[int, int, int]] = [(0, 0, -1)]
    visited = [False] * n

    while heap:
        weight, node, parent = heapq.heappop(heap)
        if visited[node]:
            continue
        visited[node] = True
        parents[node] = parent
        total_weight += weight
        for to, w in adj[node]:
            if not visited[to]:
                heapq.heappush(heap, (w, to, node))
    return total_weight, parents
