from dsa_practice.arrays.reverse_vowels import reverse_vowels_of_a_string, reverse_vowels_test


def test_reverse_vowels_of_a_string_mixed_case():
    assert reverse_vowels_of_a_string("IceCreAm") == "AceCreIm"


def test_reverse_vowels_of_a_string_leetcode():
    assert reverse_vowels_of_a_string("leetcode") == "leotcede"


def test_reverse_vowels_of_a_string_empty():
    assert reverse_vowels_of_a_string("") == ""


def test_reverse_vowels_test_expected_value():
    assert reverse_vowels_test() == "leotcede"


def test_reverse_vowels_test_returns_string():
    assert isinstance(reverse_vowels_test(), str)


def test_reverse_vowels_test_length():
    assert len(reverse_vowels_test()) == 8
