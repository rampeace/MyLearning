from dsa_practice.arrays.max_consecutive_ones import get_max_consecutive_ones, INT_MIN


def test_get_max_consecutive_ones_typical():
    assert get_max_consecutive_ones([1, 1, 0, 1]) == 2


def test_get_max_consecutive_ones_all_zero():
    assert get_max_consecutive_ones([0, 0, 0]) == 0


def test_get_max_consecutive_ones_empty():
    assert get_max_consecutive_ones([]) == INT_MIN
