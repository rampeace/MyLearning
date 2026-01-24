"""Question:
Compute the number of BFS levels (max distance) from a starting node.
"""

"""Notes:
- Graph uses Node objects with a 1D neighbors list.
- BFS level is the number of edges from the start node.
- Example adjacency: [[1, 2], [0, 3], [0, 3], [1, 2]].
"""

from collections import deque
from dataclasses import dataclass, field
from typing import List, Optional, Set, Tuple


@dataclass(eq=False)
class Node:
    val: int
    neighbors: List["Node"] = field(default_factory=list)

    __hash__ = object.__hash__


def graph_levels(start: Optional[Node]) -> int:
    if start is None:
        return 0
    visited: Set[Node] = {start}
    queue: deque[Tuple[Node, int]] = deque([(start, 0)])
    max_level = 0
    while queue:
        node, level = queue.popleft()
        max_level = level
        for neighbor in node.neighbors:
            if neighbor not in visited:
                visited.add(neighbor)
                queue.append((neighbor, level + 1))
    return max_level
