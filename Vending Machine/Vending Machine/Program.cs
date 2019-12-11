using System;
using System.Collections.Generic;

namespace Vending_Machine
{   //  10/10 
    public class Product
    {
        private string name;
        private double price;
        private int stock;
        
        public Product(string name,double price,int stock)
        {
            this.name = name;
            this.price = price;
            this.stock = stock;
        }
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
        

        //      10/10
        public static void Display(List<Product> products)
        {
            Console.WriteLine("0.Exit");
            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine((i + 1).ToString() + "." + products[i].Name + "........." + products[i].Price);
            }

        }
        //      10/10
        public static void AddProducts(List<Product> products)
        {
            products.Add(new Product("Coca Cola", 4.5, 30));
            products.Add(new Product("Sprite", 4.5, 10));
            products.Add(new Product("Fanta", 4.5, 10));
            products.Add(new Product("Snickers", 2.5, 10));
            products.Add(new Product("Mars", 2.5, 10));
            products.Add(new Product("Twix", 3.5, 10));
            products.Add(new Product("Viva", 6.5, 5));
            products.Add(new Product("Red Bull", 5.0, 15));
        }
        //      8/10
        public static void Main()
        {
            List<Product> products = new List<Product>();

            AddProducts(products);
            Display(products);



        }
    }
}