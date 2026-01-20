"""Squares of a sorted array."""

# C# SortedSquares.FindSortedSquares

def find_sorted_squares(nums=None):
    """Return the sorted squares of a sorted input array.

    Problem: Given a sorted array, return a new array of squared values sorted.
    Approach: Two pointers from ends fill the result from the back.
    Time complexity: O(n)
    Space complexity: O(n)
    """
    if nums is None:
        nums = [-4, -1, 0, 2, 3]

    result = [0] * len(nums)
    left = 0
    right = len(nums) - 1
    index = len(nums) - 1

    while left <= right:
        if abs(nums[left]) > abs(nums[right]):
            result[index] = nums[left] ** 2
            left += 1
        else:
            result[index] = nums[right] ** 2
            right -= 1
        index -= 1

    return result
