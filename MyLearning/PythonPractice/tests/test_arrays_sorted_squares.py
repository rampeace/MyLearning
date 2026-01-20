from dsa_practice.arrays.sorted_squares import find_sorted_squares


def test_find_sorted_squares_typical():
    assert find_sorted_squares([-4, -1, 0, 3, 10]) == [0, 1, 9, 16, 100]


def test_find_sorted_squares_single():
    assert find_sorted_squares([0]) == [0]


def test_find_sorted_squares_all_negative():
    assert find_sorted_squares([-2, -1]) == [1, 4]
