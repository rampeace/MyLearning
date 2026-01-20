import pytest

from dsa_practice.arrays.array_rotation import rotate_array_using_reverse, _reverse


def test_rotate_array_using_reverse_default():
    assert rotate_array_using_reverse() == [5, 6, 7, 1, 2, 3, 4]


def test_rotate_array_using_reverse_small():
    assert rotate_array_using_reverse([1, 2, 3], 1) == [3, 1, 2]


def test_rotate_array_using_reverse_k_gt_len():
    assert rotate_array_using_reverse([1, 2, 3], 4) == [3, 1, 2]


def test_reverse_middle_segment():
    arr = [1, 2, 3, 4]
    _reverse(arr, 1, 2)
    assert arr == [1, 3, 2, 4]


def test_reverse_full_segment():
    arr = [1, 2, 3, 4]
    _reverse(arr, 0, 3)
    assert arr == [4, 3, 2, 1]


def test_reverse_single_element_segment():
    arr = [1, 2, 3]
    _reverse(arr, 1, 1)
    assert arr == [1, 2, 3]
