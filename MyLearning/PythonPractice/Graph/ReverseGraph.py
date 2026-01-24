"""Question:
Reverse the direction of all edges in a directed graph.
"""

"""Notes:
- graph is a 2D adjacency list.
- reversed_graph[to] includes from for each original edge.
- Example graph:
  [
    [1, 2],
    [2],
    [0]
  ]
"""

from typing import List


def reverse_graph(graph: List[List[int]]) -> List[List[int]]:
    reversed_graph = [[] for _ in range(len(graph))]
    for frm, neighbors in enumerate(graph):
        for to in neighbors:
            reversed_graph[to].append(frm)
    return reversed_graph
