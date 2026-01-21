"""Longest consecutive sequence utilities."""

# C# LongestConsecutive.LongestConsecutiveSequenceSlidingWindow

def longest_consecutive_sequence_sliding_window(nums=None):
    """Return the longest consecutive sequence after sorting.

    Problem: Find the longest sequence of consecutive integers.
    Approach: Sort then track a sliding window of consecutive values.
    Time complexity: O(n log n)
    Space complexity: O(1) extra (in-place sort)
    """
    if nums is None:
        nums = [102, 4, 4, 4, 4, 4, 4, 44, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 100, 1, 101, 3, 2, 1, 1]

    if not nums:
        return []

    nums = list(nums)
    nums.sort()

    max_length = 1
    best_range = (0, 1)
    window_start = 0

    for window_end in range(1, len(nums)):
        curr = nums[window_end]
        previous = nums[window_end - 1]

        if curr - previous != 1:
            window_start = window_end

        window_length = window_end - window_start + 1
        if window_length > max_length:
            max_length = window_length
            best_range = (window_start, window_end + 1)

    return nums[best_range[0]:best_range[1]]


# C# LongestConsecutive.LongestConsecutiveSequenceHashsetApproach

def longest_consecutive_sequence_hashset(nums=None):
    """Return the length of the longest consecutive sequence using a set.

    Problem: Find the longest consecutive integer run.
    Approach: Use a set to expand sequences from their starting numbers.
    Time complexity: O(n)
    Space complexity: O(n)
    """
    if nums is None:
        nums = [102, 4, 4, 4, 4, 4, 4, 44, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 100, 1, 101, 3, 2, 1, 1]

    if not nums:
        return 0

    seen = set(nums)
    max_length = 0

    for num in nums:
        if num - 1 not in seen:
            current = num
            count = 0

            while current in seen:
                current += 1
                count += 1

            if count > max_length:
                max_length = count

    return max_length
