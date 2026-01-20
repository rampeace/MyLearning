from dsa_practice.arrays.dnf import dutch_national_flag


def test_dutch_national_flag_simple():
    assert dutch_national_flag([2, 0, 1]) == [0, 1, 2]


def test_dutch_national_flag_mixed():
    assert dutch_national_flag([0, 0, 1, 2, 1, 0]) == [0, 0, 0, 1, 1, 2]


def test_dutch_national_flag_empty():
    assert dutch_national_flag([]) == []
