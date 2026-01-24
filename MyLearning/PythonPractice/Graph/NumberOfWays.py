"""Question:
Count the number of shortest paths from 0 to n-1 in a weighted graph, modulo 1e9+7.
"""

"""Notes:
- roads is a 2D list: [[u, v, time], ...], undirected.
- Use Dijkstra to compute shortest time and count paths.
- Example roads:
  [
    [0, 1, 2],
    [1, 2, 3],
    [0, 2, 4]
  ]
"""

import heapq
from typing import List, Tuple


def number_of_ways(n: int, roads: List[List[int]]) -> int:
    mod = 1_000_000_007
    adj: List[List[Tuple[int, int]]] = [[] for _ in range(n)]
    for u, v, t in roads:
        adj[u].append((v, t))
        adj[v].append((u, t))

    dist = [float("inf")] * n
    ways = [0] * n
    dist[0] = 0
    ways[0] = 1
    heap: List[Tuple[int, int]] = [(0, 0)]
    while heap:
        time, node = heapq.heappop(heap)
        if time > dist[node]:
            continue
        for to, edge_time in adj[node]:
            new_time = time + edge_time
            if new_time < dist[to]:
                dist[to] = new_time
                ways[to] = ways[node]
                heapq.heappush(heap, (new_time, to))
            elif new_time == dist[to]:
                ways[to] = (ways[to] + ways[node]) % mod
    return ways[-1] % mod
