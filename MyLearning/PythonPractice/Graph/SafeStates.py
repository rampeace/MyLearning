"""Question:
Return all eventual safe nodes in a directed graph.
"""

"""Notes:
- graph is a 2D adjacency list.
- Reverse graph and process nodes with outdegree 0.
- Example graph:
  [
    [1, 2],
    [2, 3],
    [5],
    [0],
    [5],
    [],
    []
  ]
"""

from collections import deque
from typing import List


def reverse_graph(graph: List[List[int]]) -> List[List[int]]:
    reversed_graph = [[] for _ in range(len(graph))]
    for frm, neighbors in enumerate(graph):
        for to in neighbors:
            reversed_graph[to].append(frm)
    return reversed_graph


def eventual_safe_nodes(graph: List[List[int]]) -> List[int]:
    reversed_graph = reverse_graph(graph)
    outdegree = [len(neighbors) for neighbors in graph]
    queue: deque[int] = deque([i for i, deg in enumerate(outdegree) if deg == 0])
    safe: List[int] = []
    while queue:
        node = queue.popleft()
        safe.append(node)
        for neighbor in reversed_graph[node]:
            outdegree[neighbor] -= 1
            if outdegree[neighbor] == 0:
                queue.append(neighbor)
    return sorted(safe)
