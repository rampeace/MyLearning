from dsa_practice.arrays.sub_string_present import (
    is_sub_string_present,
    is_sub_string_present_demo,
)


def test_is_sub_string_present_returns_false():
    assert is_sub_string_present("abc", "a") is False


def test_is_sub_string_present_empty_inputs():
    assert is_sub_string_present("", "") is False


def test_is_sub_string_present_repeated():
    assert is_sub_string_present("aaaa", "aa") is False


def test_is_sub_string_present_demo_value():
    assert is_sub_string_present_demo() is False


def test_is_sub_string_present_demo_is_bool():
    assert isinstance(is_sub_string_present_demo(), bool)


def test_is_sub_string_present_demo_not_true():
    assert is_sub_string_present_demo() is not True
