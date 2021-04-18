using System;
using System.Collections.Generic;
using System.Text;
using Vending_Machine_Repo;

namespace Vending_Machine_Repo
{
    public interface IRepository
    {
        List<Product> GetProducts();
        void AddProduct(Product product);
        void RemoveProduct(Product product);
        void ModifyProduct(int index, Product product);
        void Order(Product product);
        List<string> GetOrderHistory();
        double GetMoney();
        List<Purchase> GetPurchases();
        void Reset();
    }
}
