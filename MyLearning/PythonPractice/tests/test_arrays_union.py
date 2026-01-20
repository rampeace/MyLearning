from dsa_practice.arrays.union import find_union


def test_find_union_default():
    assert find_union() == [1, 2, 3, 4, 5, 6, 7, 8]


def test_find_union_with_duplicates():
    assert find_union([1, 2, 2, 3], [2, 2, 4]) == [1, 2, 3, 4]


def test_find_union_empty_left():
    assert find_union([], [1, 1]) == [1]
