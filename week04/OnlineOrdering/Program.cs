using System;

class Program
{
    static void Main(string[] args)
    {
        // Order 1 (Philippines)
        Address addr1 = new Address("Tiano Brother St", "Cagayan de Oro", "MisOr", "Philippines");
        Customer cust1 = new Customer("Maria Gomez", addr1);

        Order order1 = new Order(cust1);
        order1.AddProduct(new Product("Laptop", "P100", 800, 1));
        order1.AddProduct(new Product("Mouse", "P200", 20, 2));

        // Order 2 (International)
        Address addr2 = new Address("92 Dongcheon-ro", "Busanjin Districk", "Busan", "South Korea");
        Customer cust2 = new Customer("Kang Minji", addr2);

        Order order2 = new Order(cust2);
        order2.AddProduct(new Product("Phone", "P300", 600, 1));
        order2.AddProduct(new Product("Charger", "P400", 25, 3));

        // Display Orders
        DisplayOrder(order1);
        DisplayOrder(order2);
    }

    static void DisplayOrder(Order order)
    {
        Console.WriteLine("===== SHIPPING LABEL =====");
        Console.WriteLine(order.GetShippingLabel());

        Console.WriteLine("\n===== PACKING LABEL =====");
        Console.WriteLine(order.GetPackingLabel());

        Console.WriteLine($"Total Price: ${order.GetTotalCost()}");
        Console.WriteLine("\n===========================\n");
    }
}