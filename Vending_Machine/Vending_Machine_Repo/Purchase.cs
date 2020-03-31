using System;
using System.Collections.Generic;
using System.Text;

namespace Vending_Machine_Repo
{
    public class Purchase
    {
        private string ProductName;
        private int _amount;
        public Purchase(string productName, int amount)
        {
            this.ProductName = productName;
            this._amount = amount;
        }

        public string Product
        {
            get { return ProductName; }
            set { ProductName = value; }
        }

        public int Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

    }
}
