from dsa_practice.arrays.leader import find_leader


def test_find_leader_default():
    assert find_leader() == [22, 12, 6]


def test_find_leader_descending():
    assert find_leader([5, 4, 3]) == [5, 4, 3]


def test_find_leader_empty():
    assert find_leader([]) == []
