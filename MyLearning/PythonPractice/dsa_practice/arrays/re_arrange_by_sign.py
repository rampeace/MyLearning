"""Rearrange array by sign."""

# C# ReArrangeBySign.ReArrangeBySignEqualNumbersOfPositiveAndNegative

def re_arrange_by_sign_equal_numbers_of_positive_and_negative(nums=None):
    """Rearrange numbers so positives and negatives alternate, starting with positive.

    Problem: Place positive numbers at even indices and negatives at odd indices.
    Approach: Single pass, placing positives at even indices and negatives at odd.
    Time complexity: O(n)
    Space complexity: O(n)
    """
    if nums is None:
        nums = [1, -2, -3, 5, -3, 8]

    result = [0] * len(nums)
    even_index = 0
    odd_index = 1

    for num in nums:
        if num > 0:
            result[even_index] = num
            even_index += 2
        else:
            result[odd_index] = num
            odd_index += 2

    return result
