from collections import deque
from typing import List


def find_course_order(num_courses: int, prerequisites: List[List[int]]) -> List[int]:
    adj = [[] for _ in range(num_courses)]
    indegree = [0] * num_courses
    for course, prereq in prerequisites:
        adj[prereq].append(course)
        indegree[course] += 1

    queue: deque[int] = deque([i for i, deg in enumerate(indegree) if deg == 0])
    order: List[int] = []
    while queue:
        node = queue.popleft()
        order.append(node)
        for to in adj[node]:
            indegree[to] -= 1
            if indegree[to] == 0:
                queue.append(to)
    return order if len(order) == num_courses else []
