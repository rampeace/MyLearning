"""Consecutive ones counters."""

INT_MIN = -2 ** 31

# C# MaxConsecutiveOnes.GetMaxConsecutiveOnes

def get_max_consecutive_ones(array=None):
    """Return the maximum number of consecutive 1s in the array.

    Problem: Find the longest run of 1s in an array.
    Approach: Single pass counter with reset on non-1 values.
    Time complexity: O(n)
    Space complexity: O(1)
    """
    if array is None:
        array = [0, 2, 3, 1, 1, 5, 7, 1, 1, 1, 67, 1, 1]

    count = 0
    max_count = INT_MIN

    for num in array:
        if num == 1:
            count += 1
        else:
            count = 0
        if count > max_count:
            max_count = count

    return max_count
