from typing import List


def reverse_graph(graph: List[List[int]]) -> List[List[int]]:
    reversed_graph = [[] for _ in range(len(graph))]
    for frm, neighbors in enumerate(graph):
        for to in neighbors:
            reversed_graph[to].append(frm)
    return reversed_graph
