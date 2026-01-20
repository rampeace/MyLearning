"""Create all contiguous subarrays."""

# C# CreateAllSubArrays.CreateAllSubArrayss

def create_all_sub_arrayss(input_list=None):
    """Return all contiguous subarrays.

    Problem: Generate all contiguous subarrays of an input list.
    Approach: Expand a window from each start index and capture each subarray.
    Time complexity: O(n^2)
    Space complexity: O(n^2)
    """
    if input_list is None:
        input_list = [1, 2, 3, 4, 5]

    sub_arrays = []

    for i in range(len(input_list)):
        current = []
        for j in range(i, len(input_list)):
            current.append(input_list[j])
            sub_arrays.append(list(current))

    return sub_arrays
