using System;
using System.Collections.Generic;
using System.Text;
using Vending_Machine_Repo;

namespace Vending_Machine_Controller
{

    public interface IServices
    {
        List<Product> GetProducts();
        void Order(int index);
        void AddProduct(string Name, double Price, int Stock);
        void RemoveProduct(int index);
        void ModifyProduct(int index, string Name, double Price, int Stock);
        bool ValidInput(string Price, string Stock);
        List<Purchase> GetSortedProducts();
        double GetMoney();
        List<string> GetOrderHistory();
        void Reset();
    }

    public class Services : IServices
    {
        IRepository repository;
        public Services(IRepository repo)
        {
            this.repository = repo;
        }
        public List<Product> GetProducts()
        {
            return repository.GetProducts();
        }

        public bool ValidInput(string Price, string Stock)
        {
            double price = 0;
            bool PriceIsDouble = double.TryParse(Price, out price);
            int stock = 0;
            bool StockIsInt = int.TryParse(Stock, out stock);

            if (PriceIsDouble && StockIsInt)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Order(int index)
        {
            List<Product> products = GetProducts();
            if (products[index].Stock == 0)
            {
                throw new Exception("Out of Stock!");
            }
            else
            {
                Product product = new Product(products[index].Name, products[index].Price, products[index].Stock - 1);
                repository.Order(product);
                repository.ModifyProduct(index, product);
            }
        }

        public List<Purchase> GetSortedProducts()
        {
            List<Purchase> purchases = repository.GetPurchases();

            for (int i = 0; i < purchases.Count - 1; i++)
            {
                for (int j = i + 1; j < purchases.Count; j++)
                {
                    if (purchases[i].Amount < purchases[j].Amount)
                    {
                        Purchase aux = purchases[j];
                        purchases[j] = purchases[i];
                        purchases[i] = aux;
                    }
                }
            }

            return purchases;
        }

        public void AddProduct(string Name, double Price, int Stock)
        {
            Product product = new Product(Name, Price, Stock);
            repository.AddProduct(product);
        }

        public void RemoveProduct(int index)
        {
            List<Product> products = GetProducts();
            repository.RemoveProduct(products[index]);
        }

        public void ModifyProduct(int index, string Name, double Price, int Stock)
        {
            Product product = new Product(Name, Price, Stock);
            repository.ModifyProduct(index, product);
        }

        public double GetMoney()
        {
            return repository.GetMoney();
        }

        public List<string> GetOrderHistory()
        {
            return repository.GetOrderHistory();
        }

        public void Reset()
        {
            repository.Reset();
        }
    }
}
