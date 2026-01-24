"""Question:
Detect whether an undirected graph contains a cycle.
"""

"""Notes:
- Graph uses Node objects with a 1D neighbors list.
- For undirected graphs, track parent to detect back edges.
- Example adjacency: [[1, 2], [0, 2], [0, 1]].
"""

from collections import deque
from dataclasses import dataclass, field
from typing import List, Optional, Set, Tuple


@dataclass(eq=False)
class Node:
    val: int
    neighbors: List["Node"] = field(default_factory=list)

    __hash__ = object.__hash__


def has_cycle_bfs(start: Optional[Node]) -> bool:
    if start is None:
        return False
    visited: Set[Node] = {start}
    queue: deque[Tuple[Node, Optional[Node]]] = deque([(start, None)])
    while queue:
        node, parent = queue.popleft()
        for neighbor in node.neighbors:
            if neighbor not in visited:
                visited.add(neighbor)
                queue.append((neighbor, node))
            elif neighbor is not parent:
                return True
    return False


def has_cycle_dfs(start: Optional[Node]) -> bool:
    if start is None:
        return False

    def dfs(node: Node, parent: Optional[Node], visited: Set[Node]) -> bool:
        for neighbor in node.neighbors:
            if neighbor not in visited:
                visited.add(neighbor)
                if dfs(neighbor, node, visited):
                    return True
            elif neighbor is not parent:
                return True
        return False

    visited: Set[Node] = {start}
    return dfs(start, None, visited)
