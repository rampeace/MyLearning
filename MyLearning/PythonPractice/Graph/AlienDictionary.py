"""Question:
Determine a valid order of letters in an alien dictionary given sorted words; return empty string if inconsistent.
"""

"""Notes:
- Input is a 1D list of strings (words).
- The first differing character between adjacent words forms a directed edge.
- Example words: ["baa", "abcd", "abca", "cab", "cad"]
- Output is any valid topological order of characters.
"""

from collections import deque
from typing import Dict, List, Set


def alien_order(words: List[str]) -> str:
    adjacency: Dict[str, Set[str]] = {}
    indegree: Dict[str, int] = {}
    for word in words:
        for ch in word:
            adjacency.setdefault(ch, set())
            indegree.setdefault(ch, 0)

    for i in range(len(words) - 1):
        first, second = words[i], words[i + 1]
        mismatch = False
        for c1, c2 in zip(first, second):
            if c1 != c2:
                if c2 not in adjacency[c1]:
                    adjacency[c1].add(c2)
                    indegree[c2] += 1
                mismatch = True
                break
        if not mismatch and len(first) > len(second):
            return ""

    queue = deque([ch for ch, deg in indegree.items() if deg == 0])
    order: List[str] = []
    while queue:
        ch = queue.popleft()
        order.append(ch)
        for nxt in adjacency[ch]:
            indegree[nxt] -= 1
            if indegree[nxt] == 0:
                queue.append(nxt)
    return "".join(order) if len(order) == len(adjacency) else ""
