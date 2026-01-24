"""Question:
Find the length of the shortest transformation sequence between two words.
"""

"""Notes:
- word_list is a 1D list of strings.
- Each step changes one character.
- Example: begin="hit", end="cog", word_list=["hot", "dot", "dog", "lot", "log", "cog"].
"""

from collections import deque
from typing import List


def word_ladder_length(begin_word: str, end_word: str, word_list: List[str]) -> int:
    word_set = set(word_list)
    if end_word not in word_set:
        return 0

    queue: deque[tuple[str, int]] = deque([(begin_word, 1)])
    while queue:
        current, steps = queue.popleft()
        for i in range(len(current)):
            for ch in "abcdefghijklmnopqrstuvwxyz":
                if ch == current[i]:
                    continue
                candidate = current[:i] + ch + current[i + 1 :]
                if candidate in word_set:
                    if candidate == end_word:
                        return steps + 1
                    word_set.remove(candidate)
                    queue.append((candidate, steps + 1))
    return 0


def word_ladder_length_naive(begin_word: str, end_word: str, word_list: List[str]) -> int:
    word_set = set(word_list)
    if end_word not in word_set:
        return 0

    def is_edge(a: str, b: str) -> bool:
        if len(a) != len(b):
            return False
        return sum(1 for i in range(len(a)) if a[i] != b[i]) == 1

    queue: deque[tuple[str, int]] = deque([(begin_word, 1)])
    while queue:
        current, steps = queue.popleft()
        to_remove: List[str] = []
        for word in word_set:
            if is_edge(current, word):
                if word == end_word:
                    return steps + 1
                queue.append((word, steps + 1))
                to_remove.append(word)
        for word in to_remove:
            word_set.remove(word)
    return 0
