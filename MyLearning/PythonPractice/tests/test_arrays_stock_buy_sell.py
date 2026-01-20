from dsa_practice.arrays.stock_buy_sell import find_stock_max_profit


def test_find_stock_max_profit_typical():
    assert find_stock_max_profit([7, 1, 5, 3, 6, 4]) == (1, 6, 5)


def test_find_stock_max_profit_no_profit():
    assert find_stock_max_profit([7, 6, 4, 3, 1]) is None


def test_find_stock_max_profit_two_days():
    assert find_stock_max_profit([1, 2]) == (1, 2, 1)
