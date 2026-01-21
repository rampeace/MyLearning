"""Nearby duplicate checks using sliding window."""

# C# ContainsDuplicate.ContainsNearbyDuplicate

def contains_nearby_duplicate(nums=None, k=3):
    """Return True if any duplicate values appear within distance k.

    Problem: Detect two equal values with index distance <= k.
    Approach: Sliding window backed by a set to track current window values.
    Time complexity: O(n)
    Space complexity: O(k)
    """
    if nums is None:
        nums = [1, 2, 3, 1, 4, 8, 1]

    window_start = 0
    seen = set()

    for window_end, value in enumerate(nums):
        while window_end - window_start > k:
            seen.discard(nums[window_start])
            window_start += 1

        if value in seen:
            return True
        seen.add(value)

    return False
