using System;
using System.Collections.Generic;
using System.Text;
using static CSharpPractice.Linq.LeftJoin;

namespace CSharpPractice.Linq
{
    internal class LeftJoin
    {
        public class Customer
        {
            public int CustomerId { get; set; }
            public string Name { get; set; }
        }

        public class Order
        {
            public int OrderId { get; set; }
            public int CustomerId { get; set; }
            public string Product { get; set; }
        }

        List<Customer> customers = new()
        {
            new Customer { CustomerId = 1, Name = "Alice" },
            new Customer { CustomerId = 2, Name = "Bob" },
            new Customer { CustomerId = 3, Name = "Charlie" }
        };

        List<Order> orders = new()
        {
            new Order { OrderId = 101, CustomerId = 1, Product = "Laptop" },
            new Order { OrderId = 102, CustomerId = 1, Product = "Mouse" },
            new Order { OrderId = 103, CustomerId = 2, Product = "Keyboard" }
        };

        public void TryLeftJoin()
        {
            //var result = customers
            //    .LeftJoin(orders, c => c.CustomerId, o => o.CustomerId, (c, o) => new
            //    {
            //        c.CustomerId,
            //        c.Name,
            //        OrderId = o?.OrderId ?? 0,
            //        Product = o?.Product ?? "No Order"
            //    });

            //foreach (var item in result)
            //{
            //    Console.WriteLine($"{item.Name} -> {item.OrderId}");
            //}
        }

        public void LeftJoinOldWay()
        {
            var result = customers
                .GroupJoin(orders, c => c.CustomerId, o => o.CustomerId, (c, orders) => new
                {
                    c.CustomerId,
                    c.Name,
                    Orders = orders
                })
                .SelectMany(o => o.Orders.DefaultIfEmpty(), (o, order) => new
                {
                    o.CustomerId,
                    o.Name,
                    OrderId = order?.OrderId ?? 0,
                    ProductName = order?.Product ?? "No Order Available"
                });
        }
    }
}
