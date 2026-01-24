from typing import Iterable, List, Tuple


def bellman_ford(v: int, edges: Iterable[Tuple[int, int, int]], src: int) -> List[int]:
    dist = [float("inf")] * v
    dist[src] = 0
    edge_list = list(edges)
    for i in range(v):
        updated = False
        for frm, to, weight in edge_list:
            if dist[frm] == float("inf"):
                continue
            new_dist = dist[frm] + weight
            if new_dist < dist[to]:
                if i == v - 1:
                    return []
                dist[to] = new_dist
                updated = True
        if not updated:
            break
    return [int(d) if d != float("inf") else 2**31 - 1 for d in dist]
