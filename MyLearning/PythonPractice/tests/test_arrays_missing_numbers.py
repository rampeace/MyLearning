from dsa_practice.arrays.missing_numbers import (
    find_missing_numbers,
    find_missing_numbers_optimal_inplace,
)


def test_find_missing_numbers_default():
    assert find_missing_numbers([4, 3, 2, 7, 8, 2, 3, 1, 10, 13]) == [5, 6, 9, 11, 12]


def test_find_missing_numbers_no_gaps():
    assert find_missing_numbers([1, 2, 3]) == []


def test_find_missing_numbers_empty():
    assert find_missing_numbers([]) == []


def test_find_missing_numbers_optimal_inplace_basic():
    nums = [4, 3, 2, 7, 8, 2, 3, 1]
    assert find_missing_numbers_optimal_inplace(nums) == [5, 6]


def test_find_missing_numbers_optimal_inplace_duplicates():
    nums = [1, 1]
    assert find_missing_numbers_optimal_inplace(nums) == [2]


def test_find_missing_numbers_optimal_inplace_missing_first():
    nums = [2, 2]
    assert find_missing_numbers_optimal_inplace(nums) == [1]
