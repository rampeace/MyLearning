from dsa_practice.arrays.re_arrange_by_sign import (
    re_arrange_by_sign_equal_numbers_of_positive_and_negative,
)


def test_re_arrange_by_sign_default():
    assert re_arrange_by_sign_equal_numbers_of_positive_and_negative(
        [1, -2, -3, 5, -3, 8]
    ) == [1, -2, 5, -3, 8, -3]


def test_re_arrange_by_sign_two_elements():
    assert re_arrange_by_sign_equal_numbers_of_positive_and_negative([1, -1]) == [1, -1]


def test_re_arrange_by_sign_order_preserved():
    assert re_arrange_by_sign_equal_numbers_of_positive_and_negative([2, -2, 3, -3]) == [
        2,
        -2,
        3,
        -3,
    ]
