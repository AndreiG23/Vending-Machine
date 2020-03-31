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
            Repository repo = new Repository();
            Services service = new Services(repo);
            UI ui = new UI(service);
            ui.MainMenu();
        }
    }
}