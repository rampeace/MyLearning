namespace DsaPractice.Arrays
{
    internal class StockBuySell
    {
        public void FindStockMaxProfit()
        {
            int[] array = { 7, 1, 5, 3, 6, 4 };

            int maxProfit = int.MinValue;
            int min = array[0];

            (int buy, int sell) result = default;

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] - min > maxProfit)
                {
                    maxProfit = array[i] - min;
                    result = (min, array[i]);
                }
                min = System.Math.Min(min, array[i]);
            }

            if (maxProfit > 0)
                Console.WriteLine($"Maximum profit can be obtained if the stock is bought on {result.buy} and sold on {result.sell}");
            else
                Console.WriteLine("No profit can be made from the given stock prices.");
        }
    }
}
