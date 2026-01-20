"""Majority element algorithms."""

# C# MajorityElement.GetMajorityElement

def get_majority_element(array=None):
    """Return the majority element and its count if it exists.

    Problem: Find an element that appears more than n/2 times.
    Approach: Count frequencies and select the max count; validate threshold.
    Time complexity: O(n)
    Space complexity: O(n)
    """
    if array is None:
        array = [1, 2, 2, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 4, 1, 2, 8, 99, 2, 4]

    if not array:
        return None

    counts = {}
    for num in array:
        counts[num] = counts.get(num, 0) + 1

    max_num = None
    max_count = -1
    for num in array:
        if counts[num] > max_count:
            max_count = counts[num]
            max_num = num

    if max_count > len(array) // 2:
        return (max_num, max_count)
    return None


# C# MajorityElement.MoorsVotingAlgorithm

def moors_voting_algorithm(array=None):
    """Return the majority element using Boyer-Moore if it exists.

    Problem: Find an element that appears more than n/2 times.
    Approach: Boyer-Moore majority vote, then validate by counting.
    Time complexity: O(n)
    Space complexity: O(1)
    """
    if array is None:
        array = [1, 2, 1, 1, 1, 1, 1, 3, 5, 4, 5]

    if not array:
        return None

    count = 0
    candidate = 0

    for value in array:
        if count == 0:
            candidate = value
        if value == candidate:
            count += 1
        else:
            count -= 1

    if array.count(candidate) > len(array) // 2:
        return candidate
    return None
