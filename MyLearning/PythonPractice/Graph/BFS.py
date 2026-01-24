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
