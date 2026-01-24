from collections import deque
from typing import List


def is_bipartite_dfs(graph: List[List[int]]) -> bool:
    colors: List[int] = [0] * len(graph)

    def dfs(node: int, color: int) -> bool:
        colors[node] = color
        for neighbor in graph[node]:
            if colors[neighbor] == 0:
                if not dfs(neighbor, -color):
                    return False
            elif colors[neighbor] == color:
                return False
        return True

    for node in range(len(graph)):
        if colors[node] == 0 and not dfs(node, 1):
            return False
    return True


def is_bipartite_bfs(graph: List[List[int]]) -> bool:
    colors: List[int] = [0] * len(graph)
    for start in range(len(graph)):
        if colors[start] != 0:
            continue
        colors[start] = 1
        queue: deque[int] = deque([start])
        while queue:
            node = queue.popleft()
            for neighbor in graph[node]:
                if colors[neighbor] == 0:
                    colors[neighbor] = -colors[node]
                    queue.append(neighbor)
                elif colors[neighbor] == colors[node]:
                    return False
    return True
