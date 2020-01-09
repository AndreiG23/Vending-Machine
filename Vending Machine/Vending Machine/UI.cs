using System;
using System.Collections.Generic;
using System.Text;


namespace Vending_Machine
{
    class UI
    {
        Services service;
        public UI(Services serv)
        {
            this.service = serv;
            
        }
        public void print_AdminMenu()
        {
            Console.WriteLine("0.Exit");
            Console.WriteLine("1.Add Product");
            Console.WriteLine("2.Remove Product");
            Console.WriteLine("3.Modify Product");
        }
        public void print_MainMenu()
        {
            Console.WriteLine("0.Exit");
            Console.WriteLine("1.Client");
            Console.WriteLine("2.Admin\n");
        }
        public void print_ClientMenu(List<Product> products)
        {
            Console.WriteLine("0.Exit");
            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine((i + 1).ToString() + "." + products[i].Name + "........." + products[i].Price+" RON");
            }
        }
        public void MainMenu()
        {
            bool isOpen = true;
            while(isOpen)
            {
                print_MainMenu();
                string command = Console.ReadLine();

                if(command=="0")
                {
                    isOpen = false;
                }
                else if(command=="1")
                {
                    ClientMenu();
                }
                else if (command == "2")
                {
                    AdminMenu();
                }
            }
        }
        public void ClientMenu()
        {
            bool isOpen = true;
            while(isOpen)
            {
                List<Product> products = this.service.GetProducts();
                print_ClientMenu(products);
                string command = Console.ReadLine();
                if (command == "0")
                {
                    isOpen = false;
                }
                for(int i=0;i<products.Count;i++)
                {
                    if(command==(i+1).ToString())
                    {
                        bool succes = true;
                        try
                        {
                            this.service.Order(i);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Out of Stock");
                            succes = false;
                        }
                        if (succes)
                            Console.WriteLine(products[i].Name + " purchased");
                    }
                }
            }
        }
        public void AdminMenu()
        {
            bool isOpen = true;
            while (isOpen)
            {
                print_AdminMenu();
                string command = Console.ReadLine();

                if (command == "0")
                {
                    isOpen = false;
                }
                else if (command == "1")
                {
                    Console.WriteLine("Name:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Price:");
                    double price = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Stock:");
                    int stock = Convert.ToInt32(Console.ReadLine());
                    this.service.AddProduct(name,price,stock);
                }
                else if (command == "2")
                {
                    Console.WriteLine("Index:");
                    int index = Convert.ToInt32(Console.ReadLine());
                    this.service.RemoveProduct(index-1);
                }
                else if (command == "3")
                {
                    Console.WriteLine("Index:");
                    int index = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Name:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Price:");
                    double price = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Stock:");
                    int stock = Convert.ToInt32(Console.ReadLine());
                    this.service.ModifyProduct(index-1,name,price,stock);
                }
            }

        }
    }
}