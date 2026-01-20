"""Stock buy/sell maximum profit."""

INT_MIN = -2 ** 31

# C# StockBuySell.FindStockMaxProfit

def find_stock_max_profit(prices=None):
    """Return the best buy/sell prices and profit if positive.

    Problem: Find the maximum profit from a single buy-sell transaction.
    Approach: Track the minimum price so far and best profit in one pass.
    Time complexity: O(n)
    Space complexity: O(1)
    """
    if prices is None:
        prices = [7, 1, 5, 3, 6, 4]

    if len(prices) < 2:
        return None

    max_profit = INT_MIN
    min_price = prices[0]
    result = (min_price, min_price)

    for i in range(1, len(prices)):
        if prices[i] - min_price > max_profit:
            max_profit = prices[i] - min_price
            result = (min_price, prices[i])
        if prices[i] < min_price:
            min_price = prices[i]

    if max_profit > 0:
        return (result[0], result[1], max_profit)
    return None
