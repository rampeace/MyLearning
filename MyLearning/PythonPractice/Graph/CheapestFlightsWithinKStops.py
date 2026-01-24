"""Question:
Find the cheapest flight price from src to dst with at most k stops.
"""

"""Notes:
- Flights is a 2D list: [[from, to, price], ...].
- Stops count edges, not cities.
- Example flights:
  [
    [0, 1, 100],
    [1, 2, 100],
    [1, 3, 600],
    [2, 3, 200]
  ]
"""

import heapq
from typing import Dict, List, Tuple


def cheapest_flight_within_k_stops(
    n: int, flights: List[List[int]], src: int, dst: int, k: int
) -> int:
    adj: List[List[Tuple[int, int]]] = [[] for _ in range(n)]
    for frm, to, price in flights:
        adj[frm].append((to, price))

    heap: List[Tuple[int, int, int]] = [(0, src, 0)]
    best: Dict[Tuple[int, int], int] = {(src, 0): 0}

    while heap:
        cost, node, stops = heapq.heappop(heap)
        if node == dst:
            return cost
        if stops > k:
            continue
        if cost > best.get((node, stops), float("inf")):
            continue
        for to, price in adj[node]:
            new_cost = cost + price
            new_stops = stops + 1
            key = (to, new_stops)
            if new_cost < best.get(key, float("inf")):
                best[key] = new_cost
                heapq.heappush(heap, (new_cost, to, new_stops))
    return -1
