"""Question:
Implement a weighted undirected graph with BFS/DFS traversal and structure printing.
"""

"""Notes:
- Nodes have id and name; edges have weights.
- add_edge builds an undirected edge in adjacency list.
- Example edges (1D list): [(0, 1, 2), (0, 2, 4), (1, 3, 7)].
"""

from collections import deque
from dataclasses import dataclass
from typing import Deque, Dict, List, Set


@dataclass(frozen=True)
class Node:
    id: int
    name: str

    def __str__(self) -> str:
        return self.name


@dataclass(frozen=True)
class Edge:
    from_node: Node
    to_node: Node
    weight: int

    def __str__(self) -> str:
        return f"{self.from_node} --({self.weight})-- {self.to_node}"


class Graph:
    def __init__(self) -> None:
        self._adjacency: Dict[Node, List[Edge]] = {}

    def add_node(self, node: Node) -> None:
        self._adjacency.setdefault(node, [])

    def add_edge(self, from_node: Node, to_node: Node, weight: int) -> None:
        self.add_node(from_node)
        self.add_node(to_node)
        self._adjacency[from_node].append(Edge(from_node, to_node, weight))
        self._adjacency[to_node].append(Edge(to_node, from_node, weight))

    def dfs(self, start: Node) -> List[Node]:
        visited: Set[Node] = set()
        order: List[Node] = []

        def walk(node: Node) -> None:
            if node in visited:
                return
            visited.add(node)
            order.append(node)
            for edge in self._adjacency.get(node, []):
                walk(edge.to_node)

        walk(start)
        return order

        def bfs(self, start: Node) -> List[Node]:
            visited: Set[Node] = {start}
            order: List[Node] = []
            queue: Deque[Node] = deque([start])
            while queue:
                node = queue.popleft()
                order.append(node)
                for edge in self._adjacency.get(node, []):
                    if edge.to_node not in visited:
                        visited.add(edge.to_node)
                        queue.append(edge.to_node)
            return order

    def print_graph(self) -> List[str]:
        lines: List[str] = []
        for node, edges in self._adjacency.items():
            parts = [f"-> {edge.to_node.id}({edge.weight})" for edge in edges]
            lines.append(f"Node {node.id}: " + " ".join(parts))
        return lines
