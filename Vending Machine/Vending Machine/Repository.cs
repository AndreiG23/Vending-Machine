using System;
using System.Collections.Generic;
using System.Text;

namespace Vending_Machine
{
    class Repository
    {
        List<Product> products = new List<Product>();
        public Repository()
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
        public void ModifyProduct(int index,string Name,double Price,int stock)
        {
            products[index] = new Product(Name, Price, stock);
        }

    }
}
