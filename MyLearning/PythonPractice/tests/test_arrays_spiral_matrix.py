from dsa_practice.arrays.spiral_matrix import print_spiral_matrix


def test_print_spiral_matrix_default():
    assert print_spiral_matrix() == list(range(1, 37))


def test_print_spiral_matrix_small_square():
    assert print_spiral_matrix([[1, 2], [3, 4]]) == [1, 2, 4, 3]


def test_print_spiral_matrix_rectangular():
    assert print_spiral_matrix([[1, 2, 3], [4, 5, 6]]) == [1, 2, 3, 6, 5, 4]
