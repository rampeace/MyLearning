from collections import deque
from typing import List


def minimum_multiplications(arr: List[int], start: int, end: int) -> int:
    if start == end:
        return 0
    mod = 100000
    dist = [-1] * mod
    dist[start] = 0
    queue: deque[int] = deque([start])
    while queue:
        node = queue.popleft()
        for num in arr:
            nxt = (node * num) % mod
            if dist[nxt] == -1:
                dist[nxt] = dist[node] + 1
                if nxt == end:
                    return dist[nxt]
                queue.append(nxt)
    return -1
