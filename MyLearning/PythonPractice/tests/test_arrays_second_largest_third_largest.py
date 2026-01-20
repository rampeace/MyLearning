from dsa_practice.arrays.second_largest_third_largest import (
    find_second_largest,
    find_third_largest,
    second_smallest_element,
    find_third_smallest,
    INT_MIN,
)


def test_find_second_largest_default():
    assert find_second_largest([10, 20, 4, 45, 99, 99]) == 45


def test_find_second_largest_no_distinct():
    assert find_second_largest([1, 1, 1]) == INT_MIN


def test_find_second_largest_negative_values():
    assert find_second_largest([-5, -2, -3]) == -3


def test_find_third_largest_default():
    assert find_third_largest([10, 20, 4, 45, 99, 99]) == 20


def test_find_third_largest_not_found():
    assert find_third_largest([1, 2]) is None


def test_find_third_largest_negative_values():
    assert find_third_largest([-1, -2, -3, -4]) == -3


def test_second_smallest_element_default():
    assert second_smallest_element([10, 2, 4, 20, 4, 45, 99, 99]) == 4


def test_second_smallest_element_not_found():
    assert second_smallest_element([1]) is None


def test_second_smallest_element_with_duplicates():
    assert second_smallest_element([3, 3, 2]) == 3


def test_find_third_smallest_default():
    assert find_third_smallest([10, 20, 4, 45, 2, 99, 99]) == 10


def test_find_third_smallest_not_found():
    assert find_third_smallest([1, 2]) is None


def test_find_third_smallest_basic():
    assert find_third_smallest([5, 1, 2, 3]) == 3
