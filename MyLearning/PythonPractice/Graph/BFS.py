"""Question:
Perform a breadth-first traversal of a graph starting from a given node.
"""

"""Notes:
- Graph uses Node objects with a 1D neighbors list.
- BFS visits nodes level by level from the start node.
- Example adjacency (1D list of lists): [[1, 2], [0, 3], [0, 3], [1, 2]].
"""

from collections import deque
from dataclasses import dataclass, field
from typing import List, Optional, Set


@dataclass(eq=False)
class Node:
    val: int
    neighbors: List["Node"] = field(default_factory=list)

    __hash__ = object.__hash__


def bfs_graph(start: Optional[Node]) -> List[int]:
    if start is None:
        return []
    order: List[int] = []
    visited: Set[Node] = {start}
    queue: deque[Node] = deque([start])
    while queue:
        node = queue.popleft()
        order.append(node.val)
        for neighbor in node.neighbors:
            if neighbor not in visited:
                visited.add(neighbor)
                queue.append(neighbor)
    return order
