"""Find second/third largest and smallest distinct elements."""

INT_MIN = -2 ** 31
INT_MAX = 2 ** 31 - 1

# C# SecondLargestThirdLargest.FindSecondLargest

def find_second_largest(array=None):
    """Return the second largest distinct element or INT_MIN if missing.

    Problem: Find the second largest distinct value in an array.
    Approach: Track first and second largest with a single pass.
    Time complexity: O(n)
    Space complexity: O(1)
    """
    if array is None:
        array = [10, 20, 4, 45, 99, 99]

    first_largest = INT_MIN
    second_largest = INT_MIN

    for num in array:
        if num > first_largest:
            second_largest = first_largest
            first_largest = num
        elif num > second_largest and num != first_largest:
            second_largest = num

    return second_largest


# C# SecondLargestThirdLargest.FindThirdLargest

def find_third_largest(array=None):
    """Return the third largest distinct element or None if missing.

    Problem: Find the third largest distinct value in an array.
    Approach: Track top three distinct values in one pass.
    Time complexity: O(n)
    Space complexity: O(1)
    """
    if array is None:
        array = [10, 20, 4, 45, 99, 99]

    first_largest = INT_MIN
    second_largest = INT_MIN
    third_largest = INT_MIN

    for num in array:
        if num > first_largest:
            third_largest = second_largest
            second_largest = first_largest
            first_largest = num
        elif num > second_largest and num < first_largest:
            third_largest = second_largest
            second_largest = num
        elif num > third_largest and num < second_largest:
            third_largest = num

    if third_largest == INT_MIN:
        return None
    return third_largest


# C# SecondLargestThirdLargest.SecondSmallestElement

def second_smallest_element(array=None):
    """Return the second smallest distinct element or None if missing.

    Problem: Find the second smallest distinct value in an array.
    Approach: Track first and second smallest in one pass.
    Time complexity: O(n)
    Space complexity: O(1)
    """
    if array is None:
        array = [10, 2, 4, 20, 4, 45, 99, 99]

    first_smallest = INT_MAX
    second_smallest = INT_MAX

    for num in array:
        if num < first_smallest:
            second_smallest = first_smallest
            first_smallest = num
        elif num < second_smallest and num != first_smallest:
            second_smallest = num

    if second_smallest == INT_MAX:
        return None
    return second_smallest


# C# SecondLargestThirdLargest.FindThirdSmallest

def find_third_smallest(array=None):
    """Return the third smallest distinct element or None if missing.

    Problem: Find the third smallest distinct value in an array.
    Approach: Track three smallest distinct values in one pass.
    Time complexity: O(n)
    Space complexity: O(1)
    """
    if array is None:
        array = [10, 20, 4, 45, 2, 99, 99]

    first_smallest = INT_MAX
    second_smallest = INT_MAX
    third_smallest = INT_MAX

    for num in array:
        if num < first_smallest:
            third_smallest = second_smallest
            second_smallest = first_smallest
            first_smallest = num
        elif num < second_smallest and num > first_smallest:
            third_smallest = second_smallest
            second_smallest = num
        elif num < third_smallest and num > second_smallest:
            third_smallest = num

    if third_smallest == INT_MAX:
        return None
    return third_smallest
