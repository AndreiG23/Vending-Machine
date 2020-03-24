using System;
using System.Collections.Generic;
using System.Text;

namespace Vending_Machine
{
    class Product
    {
        private string name;
        private double price;
        private int stock;

        public Product(string name, double price, int stock)
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
}
