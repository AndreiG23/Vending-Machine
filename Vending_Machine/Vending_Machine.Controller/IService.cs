using System;
using System.Collections.Generic;
using System.Text;
using Vending_Machine_Repo;

namespace Vending_Machine_Controller
{
    public interface IService
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
}
