import pytest

from dsa_practice.arrays.convert2d_to1d import convert2d_array_to1d, convert1d_array_to2d


def test_convert2d_array_to1d_default():
    assert convert2d_array_to1d() == [
        1, 1, 1, 1,
        1, 0, 1, 1,
        1, 1, 0, 1,
        1, 0, 0, 1,
    ]


def test_convert2d_array_to1d_small():
    assert convert2d_array_to1d([[1, 2], [3, 4]]) == [1, 2, 3, 4]


def test_convert2d_array_to1d_empty():
    assert convert2d_array_to1d([]) == []


def test_convert1d_array_to2d_default():
    assert convert1d_array_to2d() == [
        [1, 1, 1, 1],
        [1, 0, 1, 1],
        [1, 1, 0, 1],
        [1, 0, 0, 1],
    ]


def test_convert1d_array_to2d_small():
    assert convert1d_array_to2d([1, 2, 3, 4], rows=2, cols=2) == [[1, 2], [3, 4]]


def test_convert1d_array_to2d_short_array():
    with pytest.raises(IndexError):
        convert1d_array_to2d([1, 2, 3], rows=2, cols=2)
