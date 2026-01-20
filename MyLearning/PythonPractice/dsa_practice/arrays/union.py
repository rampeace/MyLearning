"""Union of two sorted arrays."""

# C# Union.FindUnion

def find_union(array1=None, array2=None):
    """Return the union of two sorted arrays without duplicates.

    Problem: Merge two sorted arrays into a sorted union without duplicates.
    Approach: Two-pointer merge with last-value deduplication.
    Time complexity: O(n + m)
    Space complexity: O(n + m)
    """
    if array1 is None:
        array1 = [1, 1, 2, 3, 4, 5]
    if array2 is None:
        array2 = [2, 3, 4, 4, 5, 5, 6, 7, 8]

    i = 0
    j = 0
    result = []

    def append_if_new(value):
        if not result or result[-1] != value:
            result.append(value)

    while i < len(array1) and j < len(array2):
        if array1[i] <= array2[j]:
            append_if_new(array1[i])
            i += 1
        else:
            append_if_new(array2[j])
            j += 1

    while i < len(array1):
        append_if_new(array1[i])
        i += 1

    while j < len(array2):
        append_if_new(array2[j])
        j += 1

    return result
