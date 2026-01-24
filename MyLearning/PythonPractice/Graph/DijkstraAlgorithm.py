"""Question:
Find shortest paths from a source in a non-negative weighted graph.
"""

"""Notes:
- adjacency is a 1D list of lists of (to, weight).
- Example adjacency: [[(1, 2), (2, 4)], [(2, 1), (3, 7)], [(4, 3)], [(4, 1)], []].
"""

import heapq
from typing import List, Tuple


def dijkstra(adjacency: List[List[Tuple[int, int]]], source: int) -> List[int]:
    n = len(adjacency)
    dist = [float("inf")] * n
    dist[source] = 0
    heap: List[Tuple[int, int]] = [(0, source)]
    while heap:
        current_dist, node = heapq.heappop(heap)
        if current_dist > dist[node]:
            continue
        for to, weight in adjacency[node]:
            new_dist = current_dist + weight
            if new_dist < dist[to]:
                dist[to] = new_dist
                heapq.heappush(heap, (new_dist, to))
    return [int(d) if d != float("inf") else 2**31 - 1 for d in dist]
