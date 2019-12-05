using System;

namespace Vending_Machine
{
    class Product
    {
        private string name;
        private double price;
        private int stock;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public double Price
        {
            get { return price; }
            set { price = value; }
        }
        public int Stock
        {
            get { return stock; }
            set { stock = value; }
        }
    }
    class Program
    {
        public static void Display(Product[] products)
        {
            Console.WriteLine("0.Exit");
            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine((i + 1).ToString() + "." + products[i].Name + "........." + products[i].Price);
            }

        }
        public static void Main()
        {
            int numberOfProducts = 8;
            Product[] products = new Product[numberOfProducts];
            products[0] = new Product();
            products[0].Name="Coca Cola";
            products[0].Price = 4.5;
            products[0].Stock = 30;

            products[1] = new Product();
            products[1].Name = "Sprite";
            products[1].Price = 4.5;
            products[1].Stock = 10;

            products[2] = new Product();
            products[2].Name = "Fanta";
            products[2].Price = 4.5;
            products[2].Stock = 10;

            products[3] = new Product();
            products[3].Name = "Snickers";
            products[3].Price = 2.5;
            products[3].Stock = 10;

            products[4] = new Product();
            products[4].Name = "Mars";
            products[4].Price = 2.5;
            products[4].Stock = 10;

            products[5] = new Product();
            products[5].Name = "Twix";
            products[5].Price = 3.5;
            products[5].Stock = 10;

            products[6] = new Product();
            products[6].Name = "Viva";
            products[6].Price = 6.5;
            products[6].Stock = 5;

            products[7] = new Product();
            products[7].Name = "Red Bull";
            products[7].Price = 5.0;
            products[7].Stock = 15;

            Display(products);



        }
    }
}