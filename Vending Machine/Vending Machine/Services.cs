using System;
using System.Collections.Generic;
using System.Text;

namespace Vending_Machine
{
    class Services
    {
        Repository repository;
        public Services(Repository repo)
        {
            this.repository = repo;
        }
        public List<Product> GetProducts()
        {
            return this.repository.GetProducts();
        }
        public void Order(int index)
        {
            List<Product> products = this.repository.GetProducts();
            if (products[index].Stock == 0)
                throw new Exception("Out of Stock!");
            else
            {
                this.repository.ModifyProduct(index, products[index].Name, products[index].Price, products[index].Stock - 1);

            }
        }
        public void AddProduct(string Name,double Price,int Stock)
        {
            Product product = new Product(Name, Price, Stock);
            this.repository.AddProduct(product);
        }
        public void RemoveProduct(int index)
        {
            List<Product> products = this.repository.GetProducts();
            this.repository.RemoveProduct(products[index]);
        }
        public void ModifyProduct(int index,string Name,double Price,int Stock)
        {
            List<Product> products = this.repository.GetProducts();
            this.repository.ModifyProduct(index, Name,Price,Stock);
        }
    }
}
