import heapq
from typing import List, Tuple


def minimum_effort_path(heights: List[List[int]]) -> int:
    rows, cols = len(heights), len(heights[0])
    effort = [[float("inf")] * cols for _ in range(rows)]
    effort[0][0] = 0
    heap: List[Tuple[int, int, int]] = [(0, 0, 0)]
    while heap:
        current, r, c = heapq.heappop(heap)
        if (r, c) == (rows - 1, cols - 1):
            return current
        if current > effort[r][c]:
            continue
        for dr, dc in [(-1, 0), (1, 0), (0, -1), (0, 1)]:
            nr, nc = r + dr, c + dc
            if 0 <= nr < rows and 0 <= nc < cols:
                step = abs(heights[r][c] - heights[nr][nc])
                next_effort = max(current, step)
                if next_effort < effort[nr][nc]:
                    effort[nr][nc] = next_effort
                    heapq.heappush(heap, (next_effort, nr, nc))
    return 0
