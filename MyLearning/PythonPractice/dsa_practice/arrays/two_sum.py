"""Two-sum pair finding algorithms."""

# C# TwoSum.FindTwoSum

def find_two_sum(array=None, target=14):
    """Return unique pairs that sum to target using a hash set.

    Problem: Find pairs of values that sum to a target.
    Approach: Track seen values and avoid duplicate pairs.
    Time complexity: O(n * p) for duplicate checks, typically O(n)
    Space complexity: O(n)
    """
    if array is None:
        array = [2, 6, 4, 6, 8, 5, 8, 1, 1, 10]

    pairs = []
    seen = set()

    for x in array:
        y = target - x
        if y in seen:
            if (y, x) not in pairs and (x, y) not in pairs:
                pairs.append((x, y))
        seen.add(x)

    return pairs


# C# TwoSum.TwoSumOpimal

def two_sum_opimal(array=None, target=14):
    """Return pairs that sum to target using sorting and two pointers.

    Problem: Find pairs of values that sum to a target.
    Approach: Sort the array and move two pointers inward.
    Time complexity: O(n log n)
    Space complexity: O(n) for the sorted copy
    """
    if array is None:
        array = [2, 6, 4, 6, 8, 5, 8, 1, 1, 10]

    nums = list(array)
    nums.sort()

    left = 0
    right = len(nums) - 1
    pairs = []

    while left < right:
        x = nums[left]
        y = nums[right]
        total = x + y

        if total == target:
            pairs.append((x, y))
            left += 1
            right -= 1
        elif total < target:
            left += 1
        else:
            right -= 1

    return pairs
