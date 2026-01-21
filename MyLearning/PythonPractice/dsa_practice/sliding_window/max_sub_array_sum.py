"""Maximum subarray sum utilities."""

INT_MIN = -2 ** 31

# C# MaxSubArraySum.MaxSubArraySumFixedSlidingWindow

def max_subarray_sum_fixed_sliding_window(array=None, k=3):
    """Return the max-sum subarray of size k and its sum.

    Problem: Find the fixed-size subarray with maximum sum.
    Approach: Sliding window with incremental sum updates.
    Time complexity: O(n)
    Space complexity: O(1)
    """
    if array is None:
        array = [1, 4, 5, 6, 1, 2, -3, 6, 8, -9, 7, 6, 3, 3]

    if not array or k <= 0 or k > len(array):
        return [], 0

    window_sum = sum(array[:k])
    max_sum = window_sum
    best_range = (0, k)

    for i in range(k, len(array)):
        window_sum += array[i] - array[i - k]
        if window_sum > max_sum:
            best_range = (i - k + 1, i + 1)
            max_sum = window_sum

    return list(array[best_range[0]:best_range[1]]), max_sum


# C# MaxSubArraySum.KadanesAlgorithmGetSubArray

def kadanes_algorithm_get_subarray(nums=None):
    """Return the max-sum contiguous subarray and its sum.

    Problem: Find the contiguous subarray with maximum sum.
    Approach: Kadane's algorithm tracking the best start/end.
    Time complexity: O(n)
    Space complexity: O(1)
    """
    if nums is None:
        nums = [-2, 1, -3, 4, -1, 2, 1, -5, 4]

    if not nums:
        return [], 0

    current_sum = 0
    max_sum = INT_MIN
    best_range = (0, 1)
    temp_start = 0

    for i, value in enumerate(nums):
        if current_sum <= 0:
            current_sum = value
            temp_start = i
        else:
            current_sum += value

        if current_sum > max_sum:
            max_sum = current_sum
            best_range = (temp_start, i + 1)

    return list(nums[best_range[0]:best_range[1]]), max_sum


# C# MaxSubArraySum.KadanesAlgorithmGetMaxSumAnotherApproach

def kadanes_algorithm_get_max_sum(nums=None):
    """Return the maximum subarray sum.

    Problem: Find the maximum sum of any contiguous subarray.
    Approach: Kadane's algorithm with running sum reset.
    Time complexity: O(n)
    Space complexity: O(1)
    """
    if nums is None:
        nums = [2, -3, 4, -1, -2, 1, 5, -3]

    if not nums:
        return 0

    max_sum = INT_MIN
    running_sum = 0

    for num in nums:
        running_sum += num
        if running_sum > max_sum:
            max_sum = running_sum

        if running_sum < 0:
            running_sum = 0

    return max_sum


# C# MaxSubArraySum.KadanesAlgorithmGetMaxSumAnotherApproachSubArray

def kadanes_algorithm_get_max_sum_subarray(nums=None):
    """Return the max-sum contiguous subarray and its sum.

    Problem: Find the max-sum subarray even when all values are negative.
    Approach: Kadane's algorithm with range tracking.
    Time complexity: O(n)
    Space complexity: O(1)
    """
    if nums is None:
        nums = [-1, -4, -2, -5]

    if not nums:
        return [], 0

    max_sum = INT_MIN
    running_sum = 0
    best_range = (0, 1)
    temp_start = 0

    for i, num in enumerate(nums):
        running_sum += num

        if running_sum > max_sum:
            max_sum = running_sum
            best_range = (temp_start, i + 1)

        if running_sum < 0:
            running_sum = 0
            temp_start = i + 1

    return list(nums[best_range[0]:best_range[1]]), max_sum
