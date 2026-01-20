from dsa_practice.arrays.two_sum import find_two_sum, two_sum_opimal


def test_find_two_sum_default():
    assert find_two_sum() == [(8, 6), (10, 4)]


def test_find_two_sum_multiple_pairs():
    assert find_two_sum([1, 2, 3, 4], 5) == [(3, 2), (4, 1)]


def test_find_two_sum_empty():
    assert find_two_sum([], 0) == []


def test_two_sum_opimal_default():
    assert two_sum_opimal() == [(4, 10), (6, 8), (6, 8)]


def test_two_sum_opimal_multiple_pairs():
    assert two_sum_opimal([1, 2, 3, 4], 5) == [(1, 4), (2, 3)]


def test_two_sum_opimal_none():
    assert two_sum_opimal([1, 2, 3], 10) == []
