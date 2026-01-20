from dsa_practice.arrays.matrix_zeros import set_matrix_zeros_better_solution, set_matrix_zeros_optimal


def test_set_matrix_zeros_better_solution_default():
    matrix = [
        [1, 1, 1, 1],
        [1, 0, 1, 1],
        [1, 1, 0, 1],
        [1, 0, 0, 1],
    ]
    assert set_matrix_zeros_better_solution(matrix) == [
        [1, 0, 0, 1],
        [0, 0, 0, 0],
        [0, 0, 0, 0],
        [0, 0, 0, 0],
    ]


def test_set_matrix_zeros_better_solution_no_zeros():
    matrix = [[1, 2], [3, 4]]
    assert set_matrix_zeros_better_solution(matrix) == [[1, 2], [3, 4]]


def test_set_matrix_zeros_better_solution_first_row_col():
    matrix = [[0, 1], [1, 1]]
    assert set_matrix_zeros_better_solution(matrix) == [[0, 0], [0, 1]]


def test_set_matrix_zeros_optimal_default():
    matrix = [
        [1, 1, 1, 1],
        [1, 0, 1, 1],
        [1, 1, 0, 1],
        [0, 1, 1, 1],
    ]
    assert set_matrix_zeros_optimal(matrix) == [
        [0, 0, 0, 1],
        [0, 0, 0, 0],
        [0, 0, 0, 0],
        [0, 0, 0, 0],
    ]


def test_set_matrix_zeros_optimal_small():
    matrix = [[1, 0], [1, 1]]
    assert set_matrix_zeros_optimal(matrix) == [[0, 0], [1, 0]]


def test_set_matrix_zeros_optimal_no_zeros():
    matrix = [[1, 2], [3, 4]]
    assert set_matrix_zeros_optimal(matrix) == [[1, 2], [3, 4]]
