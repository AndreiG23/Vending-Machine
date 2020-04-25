using System;
using System.Collections.Generic;
using System.Text;

namespace Vending_Machine_Repo
{
    public class ProductRepository : IRepository
    {
        List<Product> products = new List<Product>();
        List<Purchase> purchases = new List<Purchase>();
        public List<string> OrderHistory = new List<string>();
        public double Money = 0;

        public ProductRepository()
        {
            FillwithProducts();
        }

        public void FillwithProducts()
        {
            products.Add(new Product("Coca Cola", 4.5, 15));
            products.Add(new Product("Sprite", 4.5, 10));
            products.Add(new Product("Fanta", 4.5, 10));
            products.Add(new Product("Snickers", 2.5, 10));
            products.Add(new Product("Mars", 2.5, 10));
            products.Add(new Product("Twix", 3.5, 10));
            products.Add(new Product("Viva", 6.5, 5));
            products.Add(new Product("Red Bull", 5.0, 15));
        }

        public void FillStock()
        {
            for (int i = 0; i < products.Count; i++)
                products[i].Stock = 15;
        }

        public List<Product> GetProducts()
        {
            return products;
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public void RemoveProduct(Product product)
        {
            products.Remove(product);
        }

        public List<Purchase> GetPurchases()
        {
            return purchases;
        }

        public void Order(Product product)
        {
            bool itExists = false;

            foreach (Purchase p in purchases)
            {
                if (product.Name == p.Product)
                {
                    p.Amount += 1;
                    itExists = true;
                }
            }
            if (!itExists)
            {
                Purchase p = new Purchase(product.Name, 1);
                purchases.Add(p);
            }
            OrderHistory.Add(product.Name);
            Money += product.Price;
        }

        public double GetMoney()
        {
            return Money;
        }

        public List<string> GetOrderHistory()
        {
            return OrderHistory;
        }

        public void ModifyProduct(int index, Product product)
        {
            products[index] = product;
        }

        public void Reset()
        {
            Money = 0;
            purchases.Clear();
            OrderHistory.Clear();
            FillStock();
        }
    }
}
