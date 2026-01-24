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
