from dsa_practice.arrays.create_all_sub_arrays import create_all_sub_arrayss


def test_create_all_sub_arrayss_typical():
    assert create_all_sub_arrayss([1, 2, 3]) == [
        [1],
        [1, 2],
        [1, 2, 3],
        [2],
        [2, 3],
        [3],
    ]


def test_create_all_sub_arrayss_single():
    assert create_all_sub_arrayss([5]) == [[5]]


def test_create_all_sub_arrayss_empty():
    assert create_all_sub_arrayss([]) == []
