using System;
using System.Collections.Generic;

namespace Vending_Machine
{  
  
    class Program
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