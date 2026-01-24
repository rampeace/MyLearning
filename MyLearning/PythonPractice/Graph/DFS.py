from dataclasses import dataclass, field
from typing import List, Optional, Set


@dataclass(eq=False)
class Node:
    val: int
    neighbors: List["Node"] = field(default_factory=list)

    __hash__ = object.__hash__


def dfs_graph(start: Optional[Node]) -> List[int]:
    if start is None:
        return []
    order: List[int] = []
    visited: Set[Node] = set()
    stack: List[Node] = [start]
    while stack:
        node = stack.pop()
        if node in visited:
            continue
        visited.add(node)
        order.append(node.val)
        for neighbor in reversed(node.neighbors):
            if neighbor not in visited:
                stack.append(neighbor)
    return order
