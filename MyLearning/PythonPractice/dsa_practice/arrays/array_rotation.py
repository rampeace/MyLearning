"""Array rotation algorithms."""

# C# ArrayRotation.RotateArrayUsingReverse

def rotate_array_using_reverse(nums=None, k=None):
    """Rotate an array to the right by k steps.

    Problem: Rotate the array so that elements are shifted right by k positions.
    Approach: Reverse the entire array, then reverse the first k elements and the rest.
    Time complexity: O(n)
    Space complexity: O(1) extra (in-place on a local list)
    """
    if nums is None:
        nums = [1, 2, 3, 4, 5, 6, 7]
    if k is None:
        k = 3

    arr = list(nums)
    if not arr:
        return arr

    k %= len(arr)

    _reverse(arr, 0, len(arr) - 1)
    _reverse(arr, 0, k - 1)
    _reverse(arr, k, len(arr) - 1)

    return arr


# C# ArrayRotation.Reverse

def _reverse(arr, left, right):
    """Reverse elements in-place between left and right indices (inclusive)."""
    while left < right:
        temp = arr[left]
        arr[left] = arr[right]
        arr[right] = temp
        left += 1
        right -= 1
