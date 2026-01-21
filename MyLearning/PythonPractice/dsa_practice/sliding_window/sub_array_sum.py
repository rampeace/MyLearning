"""Subarray sum utilities."""

# C# SubArraySum.FindLongestSubArraySum

def find_longest_subarray_sum(array=None, k=3):
    """Return the longest subarray indices whose sum equals k.

    Problem: Find the longest subarray with sum k (positive numbers).
    Approach: Sliding window with shrinking when the sum exceeds k.
    Time complexity: O(n)
    Space complexity: O(1)
    """
    if array is None:
        array = [1, 2, 3, 0, 0, 0, 1, 1, 1, 1, 4, 2, 3]

    window_start = 0
    current_sum = 0
    best = (0, -1)

    for window_end, value in enumerate(array):
        current_sum += value

        while current_sum > k and window_start <= window_end:
            current_sum -= array[window_start]
            window_start += 1

        if current_sum == k:
            current_length = window_end - window_start + 1
            best_length = best[1] - best[0] + 1
            if current_length > best_length:
                best = (window_start, window_end)

    return best


# C# SubArraySum.CountSubArraysWithSum

def count_subarrays_with_sum(array=None, k=3):
    """Return the count and index ranges for subarrays whose sum equals k.

    Problem: Count subarrays with sum k (positive numbers).
    Approach: Sliding window; shrink when the sum exceeds k.
    Time complexity: O(n)
    Space complexity: O(1)
    """
    if array is None:
        array = [1, 2, 3, 3, 1, 1, 1, 4, 3, 2, 3]

    window_start = 0
    window_sum = 0
    ranges = []

    for window_end, value in enumerate(array):
        window_sum += value

        while window_sum > k and window_start <= window_end:
            window_sum -= array[window_start]
            window_start += 1

        if window_sum == k:
            ranges.append((window_start, window_end))

    return len(ranges), ranges


# C# SubArraySum.CountSubArraysWithNegativeNumbers

def count_subarrays_with_negative_numbers(array=None, k=3):
    """Return the count of subarrays whose sum equals k.

    Problem: Count subarrays with sum k (supports negatives).
    Approach: Prefix sum with a dictionary of counts.
    Time complexity: O(n)
    Space complexity: O(n)
    """
    if array is None:
        array = [1, 2, 0, 0, 3, -3, 1, 1, 1, 4, 3, 2, -3]

    prefix_sum_count = {0: 1}
    prefix_sum = 0
    count = 0

    for value in array:
        prefix_sum += value
        target = prefix_sum - k

        count += prefix_sum_count.get(target, 0)
        prefix_sum_count[prefix_sum] = prefix_sum_count.get(prefix_sum, 0) + 1

    return count


# C# SubArraySum.CalculateSumBetweenTwoIndices

def calculate_sum_between_two_indices(nums=None, start=0, end=2):
    """Return the sum between two indices using prefix sums."""
    if nums is None:
        nums = [10, 20, 5, 15]

    if not nums or start < 0 or end >= len(nums) or start > end:
        return 0

    prefix_sum = [0] * len(nums)
    prefix_sum[0] = nums[0]

    for i in range(1, len(nums)):
        prefix_sum[i] = prefix_sum[i - 1] + nums[i]

    if start == 0:
        return prefix_sum[end]
    return prefix_sum[end] - prefix_sum[start - 1]


# C# SubArraySum.PrintSubArraysWhichSumK

def subarrays_which_sum_k(array=None, k=3):
    """Return all subarrays whose sum equals k (supports negatives).

    Problem: Find all subarrays with sum k.
    Approach: Prefix sum map that tracks all previous indices.
    Time complexity: O(n + m) where m is number of results
    Space complexity: O(n)
    """
    if array is None:
        array = [1, 2, 0, 0, 3, -3, 1, 1, 1, 4, 3, 2, -3]

    prefix_sum_map = {0: [-1]}
    prefix_sum = 0
    subarrays = []

    for i, value in enumerate(array):
        prefix_sum += value
        target = prefix_sum - k

        if target in prefix_sum_map:
            for start in prefix_sum_map[target]:
                subarrays.append(list(array[start + 1:i + 1]))

        prefix_sum_map.setdefault(prefix_sum, []).append(i)

    return subarrays
