from dsa_practice.arrays.sort_zeos_ones import sort_zeos_oness


def test_sort_zeos_oness_mixed():
    assert sort_zeos_oness([1, 0, 1, 0]) == [0, 0, 1, 1]


def test_sort_zeos_oness_all_zero():
    assert sort_zeos_oness([0, 0]) == [0, 0]


def test_sort_zeos_oness_all_one():
    assert sort_zeos_oness([1, 1]) == [1, 1]
