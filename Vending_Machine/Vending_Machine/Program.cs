using System;
using System.Collections.Generic;
using Vending_Machine_Controller;
using Vending_Machine_Repo;


namespace Vending_Machine_UI
{
    public class Program
    {
        public static void Main()
        {
            ProductRepository repo = new ProductRepository();
            ProductService service = new ProductService(repo);
            UI ui = new UI(service);
            ui.MainMenu();
        }
    }
}