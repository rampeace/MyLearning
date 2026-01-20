"""Sort zeros and ones."""

# C# SortZeosOnes.SortZeosOness

def sort_zeos_oness(array=None):
    """Sort an array containing 0s and 1s by counting zeros.

    Problem: Move all 0s to the front and 1s to the end.
    Approach: Count zeros, then overwrite positions accordingly.
    Time complexity: O(n)
    Space complexity: O(1) extra (in-place on a local list)
    """
    if array is None:
        array = [1, 0, 0, 1, 1, 1, 0, 0, 1]

    nums = list(array)
    zeros_total = 0

    for item in nums:
        if item == 0:
            zeros_total += 1

    for i in range(zeros_total):
        nums[i] = 0
    for i in range(zeros_total, len(nums)):
        nums[i] = 1

    return nums
