from dsa_practice.arrays.convert2d_to_jagged import convert_to_jagged


def test_convert_to_jagged_default():
    assert convert_to_jagged() == [
        [1, 1, 1, 1],
        [1, 0, 1, 1],
        [1, 1, 0, 1],
        [1, 0, 0, 1],
    ]


def test_convert_to_jagged_copy():
    matrix = [[1, 2], [3, 4]]
    jagged = convert_to_jagged(matrix)
    jagged[0][0] = 99
    assert matrix[0][0] == 1


def test_convert_to_jagged_empty():
    assert convert_to_jagged([]) == []
