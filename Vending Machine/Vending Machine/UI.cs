﻿using System;
using System.Collections.Generic;
using System.Text;


namespace Vending_Machine
{
    class UI
    {
        IServices service;
        public UI(IServices serv)
        {
            this.service = serv;
        }

        public void PrintAdminMenu()
        {
            Console.WriteLine("\n0.Exit");
            Console.WriteLine("1.Add Product");
            Console.WriteLine("2.Remove Product");
            Console.WriteLine("3.Modify Product");
            Console.WriteLine("4.Reports");
            Console.WriteLine("5.Reset and Fill");
        }

        public void PrintMainMenu()
        {
            Console.WriteLine("\n0.Exit");
            Console.WriteLine("1.Client");
            Console.WriteLine("2.Admin\n");
        }

        public void PrintClientMenu(List<Product> products)
        {
            Console.WriteLine("\n0.Exit");
            for (int i = 0; i < products.Count; i++)
            {
                int MenuIndex = i + 1;
                string name = products[i].Name;
                double price = products[i].Price;
                Console.WriteLine($"{MenuIndex}.{ name }.........{ price } RON");
            }
        }

        public void PrintProducts()
        {
            List<Product> products = service.GetProducts();
            for (int i = 0; i < products.Count; i++)
            {
                int stock = products[i].Stock;
                string name = products[i].Name;
                double price = products[i].Price;
                Console.WriteLine($"{i}.{ name }.........{ price } RON            Stock:{stock}");
            }
        }

        public void MainMenu()
        {
            bool isOpen = true;
            while (isOpen)
            {
                PrintMainMenu();
                string command = Console.ReadLine();
                switch (command)
                {
                    case "0":
                        {
                            isOpen = false;
                            break;
                        }
                    case "1":
                        {
                            ClientMenu();
                            break;
                        }
                    case "2":
                        {
                            AdminMenu();
                            break;
                        }
                }
            }
        }

        public void ClientMenu()
        {
            bool isOpen = true;
            while (isOpen)
            {
                List<Product> products = service.GetProducts();
                PrintClientMenu(products);
                string command = Console.ReadLine();
                if (command == "0")
                {
                    isOpen = false;
                }

                int index = 0;
                bool InputIsInt = int.TryParse(command, out index);

                if (isOpen &&InputIsInt && index>0 && index<products.Count+1)
                {
                    try
                    {
                        service.Order(index-1);
                        Console.WriteLine(products[index-1].Name + " purchased");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }

            }
        }

        public void AdminMenu()
        {
            bool isOpen = true;
            while (isOpen)
            {
                PrintAdminMenu();
                string command = Console.ReadLine();
                switch (command)
                {
                    case "0":
                        {
                            isOpen = false;
                            break;
                        }
                    case "1":
                        {
                            Console.WriteLine("Name:");
                            string name = Console.ReadLine();
                            Console.WriteLine("Price:");
                            string price = Console.ReadLine();
                            Console.WriteLine("Stock:");
                            string stock = Console.ReadLine();
                            if (service.ValidInput(price,stock))
                            {
                                service.AddProduct(name, Convert.ToDouble(price),Convert.ToInt32(stock));
                            }
                            else
                            {
                                Console.WriteLine("Invalid Input");
                            }
                            break;
                        }
                    case "2":
                        {
                            PrintProducts();
                            List<Product> products = service.GetProducts();
                            Console.WriteLine("Which product would you like to remove?");
                            Console.WriteLine("Index:");
                            int index = Convert.ToInt32(Console.ReadLine());
                            if(index>=0 && index <products.Count)
                            {
                                service.RemoveProduct(index);
                            }
                            else
                            {
                                Console.WriteLine("This product doesn't exist!!");
                            }
                            break;
                        }
                    case "3":
                        {
                            List<Product> products = service.GetProducts();
                            PrintProducts();
                            Console.WriteLine("Which product would you like to modify?");
                            Console.WriteLine("Index:");
                            int index = Convert.ToInt32(Console.ReadLine());
                            if(index <= 0 || index > products.Count)
                            {
                                Console.WriteLine("This product doesn't exist!!");
                                break;
                            }
                            Console.WriteLine("Name:");
                            string name = Console.ReadLine();
                            Console.WriteLine("Price:");
                            string price = Console.ReadLine();
                            Console.WriteLine("Stock:");
                            string stock = Console.ReadLine();
                            if (service.ValidInput(price,stock))
                            {
                                service.ModifyProduct(index, name, Convert.ToDouble(price), Convert.ToInt32(stock));
                            }
                            break;
                        }
                    case "4":
                        {
                            
                            Console.WriteLine($"Money generated by Vending Machine: {service.GetMoney()} RON");
                            List<Purchase> purchases=service.GetSortedProducts();
                            Console.WriteLine("Most purchased products are:");
                            for (int i = 0; i < purchases.Count; i++)
                            {
                                Console.WriteLine($"  {purchases[i].Amount}x{purchases[i].Product}");
                            }
                            Console.WriteLine("\nDo you want to see order history?(Y/N)");
                            string cmd = Console.ReadLine();
                            if (cmd.ToUpper()=="Y")
                            {
                                Console.WriteLine("Order History:");
                                List<string> history = service.GetOrderHistory();
                                for (int j = history.Count-1; j >=0; j--)
                                {
                                    Console.WriteLine(history[j]);
                                }
                            }
                            break;
                        }
                    case "5":
                        {
                            service.Reset();
                            Console.WriteLine("Vending Machine succesfully reseted");
                            break;
                        }
                }
            }
        }
    }
}