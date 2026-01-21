"""Contiguous increasing subsequence utilities."""

# C# ContiguousSubsequence.LongestContigousIncreasingSubsequence

def longest_contiguous_increasing_subsequence(array=None):
    """Return the longest contiguous strictly increasing subsequence.

    Problem: Find the longest contiguous subarray with strictly increasing values.
    Approach: Sliding window tracking the start of the current increasing run.
    Time complexity: O(n)
    Space complexity: O(1) extra
    """
    if array is None:
        array = [1, 3, 5, 4, 7, 9, 12, 18, 19, 2, 2, 2, 2, 2, 2, 2, 2]

    if not array:
        return []

    window_start = 0
    max_length = 1
    best_range = (0, 1)

    for window_end in range(1, len(array)):
        if array[window_end] <= array[window_end - 1]:
            window_start = window_end

        window_length = window_end - window_start + 1
        if window_length > max_length:
            best_range = (window_start, window_end + 1)
            max_length = window_length

    return list(array[best_range[0]:best_range[1]])


# C# ContiguousSubsequence.LengthLongestContigousIncreasingSubsequence

def length_longest_contiguous_increasing_subsequence(array=None):
    """Return the length of the longest contiguous strictly increasing subsequence.

    Problem: Find the length of the longest contiguous subarray with increasing values.
    Approach: Track a running count and reset when the sequence is non-increasing.
    Time complexity: O(n)
    Space complexity: O(1) extra
    """
    if array is None:
        array = [1, 3, 5, 4, 7, 9, 12, 18, 19, 2, 2, 2, 2, 2, 2, 2, 2]

    if not array:
        return 0

    max_length = 1
    count = 1

    for i in range(1, len(array)):
        if array[i] <= array[i - 1]:
            count = 0

        count += 1
        if count > max_length:
            max_length = count

    return max_length
