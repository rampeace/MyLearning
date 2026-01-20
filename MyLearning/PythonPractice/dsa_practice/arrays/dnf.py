"""Dutch National Flag sorting."""

# C# DNF.DutchNationalFlag

def dutch_national_flag(array=None):
    """Sort an array of 0s, 1s, and 2s in-place.

    Problem: Reorder the array so all 0s come first, then 1s, then 2s.
    Approach: Three pointers (low, mid, high) partition the array in one pass.
    Time complexity: O(n)
    Space complexity: O(1) extra
    """
    if array is None:
        array = [2, 1, 0, 1, 1, 2, 0, 0, 2, 1, 1, 1]

    nums = list(array)
    low = 0
    mid = 0
    high = len(nums) - 1

    while mid <= high:
        mid_value = nums[mid]

        if mid_value == 0:
            nums[low], nums[mid] = nums[mid], nums[low]
            low += 1
            mid += 1
        elif mid_value == 1:
            mid += 1
        else:
            nums[high], nums[mid] = nums[mid], nums[high]
            high -= 1

    return nums
