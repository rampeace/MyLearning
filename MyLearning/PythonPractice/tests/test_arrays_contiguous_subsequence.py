from dsa_practice.arrays.contiguous_subsequence import (
    longest_contiguous_increasing_subsequence,
    length_longest_contiguous_increasing_subsequence,
)


def test_longest_contiguous_increasing_subsequence_typical():
    array = [1, 3, 5, 4, 7, 9]
    assert longest_contiguous_increasing_subsequence(array) == [1, 3, 5]


def test_longest_contiguous_increasing_subsequence_decreasing():
    assert longest_contiguous_increasing_subsequence([5, 4, 3]) == [5]


def test_longest_contiguous_increasing_subsequence_empty():
    assert longest_contiguous_increasing_subsequence([]) == []


def test_length_longest_contiguous_increasing_subsequence_typical():
    array = [1, 3, 5, 4, 7, 9]
    assert length_longest_contiguous_increasing_subsequence(array) == 3


def test_length_longest_contiguous_increasing_subsequence_equal():
    assert length_longest_contiguous_increasing_subsequence([2, 2, 2]) == 1


def test_length_longest_contiguous_increasing_subsequence_empty():
    assert length_longest_contiguous_increasing_subsequence([]) == 0
