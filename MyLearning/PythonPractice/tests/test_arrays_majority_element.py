from dsa_practice.arrays.majority_element import get_majority_element, moors_voting_algorithm


def test_get_majority_element_found():
    assert get_majority_element([3, 3, 4]) == (3, 2)


def test_get_majority_element_none():
    assert get_majority_element([1, 2, 3, 4]) is None


def test_get_majority_element_empty():
    assert get_majority_element([]) is None


def test_moors_voting_algorithm_found():
    assert moors_voting_algorithm([2, 2, 1, 2]) == 2


def test_moors_voting_algorithm_none():
    assert moors_voting_algorithm([1, 2, 3]) is None


def test_moors_voting_algorithm_empty():
    assert moors_voting_algorithm([]) is None
