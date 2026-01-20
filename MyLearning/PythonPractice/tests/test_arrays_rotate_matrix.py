from dsa_practice.arrays.rotate_matrix import rotate_90_degrees_brute_force, rotate_90_degrees_opimal


def test_rotate_90_degrees_brute_force_default():
    assert rotate_90_degrees_brute_force() == [
        [13, 9, 5, 1],
        [14, 10, 6, 2],
        [15, 11, 7, 3],
        [16, 12, 8, 4],
    ]


def test_rotate_90_degrees_brute_force_small():
    assert rotate_90_degrees_brute_force([[1, 2], [3, 4]]) == [[3, 1], [4, 2]]


def test_rotate_90_degrees_brute_force_empty():
    assert rotate_90_degrees_brute_force([]) == []


def test_rotate_90_degrees_opimal_default():
    matrix = [
        [1, 2, 3, 4],
        [5, 6, 7, 8],
        [9, 10, 11, 12],
        [13, 14, 15, 16],
    ]
    assert rotate_90_degrees_opimal(matrix) == [
        [13, 9, 5, 1],
        [14, 10, 6, 2],
        [15, 11, 7, 3],
        [16, 12, 8, 4],
    ]


def test_rotate_90_degrees_opimal_small():
    matrix = [[1, 2], [3, 4]]
    assert rotate_90_degrees_opimal(matrix) == [[3, 1], [4, 2]]


def test_rotate_90_degrees_opimal_single():
    matrix = [[1]]
    assert rotate_90_degrees_opimal(matrix) == [[1]]
