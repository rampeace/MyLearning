"""Leader elements in an array."""

INT_MIN = -2 ** 31

# C# Leader.FindLeader

def find_leader(input_list=None):
    """Return leaders in the array (elements greater than all to their right).

    Problem: Find all elements that are greater than every element to their right.
    Approach: Traverse from the end while tracking the max seen so far.
    Time complexity: O(n)
    Space complexity: O(n) for the result list
    """
    if input_list is None:
        input_list = [10, 22, 12, 3, 0, 6]

    if not input_list:
        return []

    max_value = INT_MIN
    result_reversed = []

    for i in range(len(input_list) - 1, -1, -1):
        if i == len(input_list) - 1 or input_list[i] > max_value:
            result_reversed.append(input_list[i])
        if input_list[i] > max_value:
            max_value = input_list[i]

    return list(reversed(result_reversed))
