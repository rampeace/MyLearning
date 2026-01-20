"""Missing numbers utilities."""

# C# MissingNumbers.FindMissingNumbers

def find_missing_numbers(input_list=None):
    """Return missing integers between consecutive sorted elements.

    Problem: Given an array, find numbers missing between sorted neighbors.
    Approach: Sort the array and fill gaps between adjacent values.
    Time complexity: O(n log n)
    Space complexity: O(n) for results
    """
    if input_list is None:
        input_list = [4, 3, 2, 7, 8, 2, 3, 1, 10, 13]

    if not input_list:
        return []

    nums = list(input_list)
    nums.sort()

    result = []
    for i in range(1, len(nums)):
        curr = nums[i]
        previous = nums[i - 1]
        for value in range(previous + 1, curr):
            result.append(value)

    return result


# C# MissingNumbers.FindMissingNumbersOptimalInplace

def find_missing_numbers_optimal_inplace(input_list=None):
    """Return missing numbers in the range 1..n using in-place marking.

    Problem: For an array of size n with values in 1..n, find missing values.
    Approach: Mark indices by negating values, then collect positives.
    Time complexity: O(n)
    Space complexity: O(1) extra (in-place on input list)
    """
    if input_list is None:
        input_list = [4, 3, 2, 7, 8, 2, 3, 1, 9, 9, 9]

    nums = input_list
    for i in range(len(nums)):
        index = abs(nums[i]) - 1
        if nums[index] > 0:
            nums[index] = -nums[index]

    missing_numbers = []
    for i in range(len(nums)):
        if nums[i] > 0:
            missing_numbers.append(i + 1)

    return missing_numbers
