using System;
using System.Collections.Generic;

class Customer
{
    public int CustomerId { get; set; }
    public string Name { get; set; }
}

class Order
{
    public int OrderId { get; set; }
    public string Product { get; set; }
    public string Category { get; set; }
    public int CustomerId { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        List<Order> orders = new List<Order>();
        Dictionary<int, Customer> customers = new Dictionary<int, Customer>();
        HashSet<string> categories = new HashSet<string>();
        Queue<Order> orderQueue = new Queue<Order>();
        Stack<string> statusHistory = new Stack<string>();

        customers.Add(1, new Customer { CustomerId = 1, Name = "Haritha" });
        customers.Add(2, new Customer { CustomerId = 2, Name = "Ravi" });

        Order order1 = new Order { OrderId = 101, Product = "Laptop", Category = "Electronics", CustomerId = 1 };
        Order order2 = new Order { OrderId = 102, Product = "Shoes", Category = "Fashion", CustomerId = 2 };
        Order order3 = new Order { OrderId = 103, Product = "Mobile", Category = "Electronics", CustomerId = 1 };

        orders.Add(order1);
        orders.Add(order2);
        orders.Add(order3);

        foreach (Order order in orders)
        {
            categories.Add(order.Category);
            orderQueue.Enqueue(order);
        }

        Console.WriteLine("=== Processing Orders ===");

        while (orderQueue.Count > 0)
        {
            Order order = orderQueue.Dequeue();
            Console.WriteLine($"Order ID: {order.OrderId}, Product: {order.Product}");

            statusHistory.Push($"Order {order.OrderId} Processed");
        }

        Console.WriteLine("\n=== Order Status History ===");

        while (statusHistory.Count > 0)
        {
            Console.WriteLine(statusHistory.Pop());
        }

        Console.WriteLine("\n=== Unique Categories ===");

        foreach (string category in categories)
        {
            Console.WriteLine(category);
        }

        Console.WriteLine("\n=== Customer Details ===");

        foreach (var customer in customers)
        {
            Console.WriteLine($"Customer ID: {customer.Value.CustomerId}, Name: {customer.Value.Name}");
        }
    }
}