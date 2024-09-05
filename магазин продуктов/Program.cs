using System;
using System.Collections.Generic;

class Product
{
    public string Name { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
}

class Store
{
    private List<Product> products = new List<Product>();

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public void DisplayProducts()
    {
        foreach (var product in products)
        {
            Console.WriteLine($"Название: {product.Name}, Цена: {product.Price}, Количество: {product.Quantity}");
        }
    }

    public Product FindProduct(string name)
    {
        return products.Find(p => p.Name == name);
    }

    public void SellProduct(string name, int quantity)
    {
        Product product = FindProduct(name);
        if (product != null)
        {
            if (product.Quantity >= quantity)
            {
                product.Quantity -= quantity;
                Console.WriteLine("Товар продан.");
            }
            else
            {
                Console.WriteLine("Недостаточно товара на складе.");
            }
        }
        else
        {
            Console.WriteLine("Товар не найден.");
        }
    }
}

class Program
{
    static void Main()
    {
        Store store = new Store();

        while (true)
        {
            Console.WriteLine("1. Добавить продукт ");
            Console.WriteLine("2. Просмотреть список товаров ");
            Console.WriteLine("3. Найти товар ");
            Console.WriteLine("4. Продать товар ");
            Console.WriteLine("5. Выйти ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Product newProduct = new Product();
                    Console.Write("Введите название товара: ");
                    newProduct.Name = Console.ReadLine();
                    Console.Write(" Введите цену товара: ");
                    newProduct.Price = double.Parse(Console.ReadLine());
                    Console.Write("Введите количество товара: ");
                    newProduct.Quantity = int.Parse(Console.ReadLine());
                    store.AddProduct(newProduct);
                    break;
                case 2:
                    store.DisplayProducts();
                    break;
                case 3:
                    Console.Write("Введите название продукта, чтобы найти его: ");
                    string productName = Console.ReadLine();
                    Product foundProduct = store.FindProduct(productName);
                    if (foundProduct != null)
                    {
                        Console.WriteLine($"Название: {foundProduct.Name}, Цена: {foundProduct.Price}, Количество: {foundProduct.Quantity}");
                    }
                    else
                    {
                        Console.WriteLine("Продукт не найден.");
                    }
                    break;
                case 4:
                    Console.Write("Введите название продукта для продажи: ");
                    string productToSell = Console.ReadLine();
                    Console.Write("Введите количество для продажи: ");
                    int quantityToSell = int.Parse(Console.ReadLine());
                    store.SellProduct(productToSell, quantityToSell);
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Неверный выбор. ");
                    break;
            }
        }
    }
}
