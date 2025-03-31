using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    class Program
    {
        public class FoodItem
        {
            public int ID { get; }
            public string Name { get; }
            public double Price { get; }
            public string Category { get; }

            public FoodItem(int id, string name, double price, string category)
            {
                ID = id;
                Name = name;
                Price = price;
                Category = category;
            }
        }


        public static List<FoodItem> menu = new List<FoodItem>();
        public static Dictionary<int, FoodItem> orders = new Dictionary<int, FoodItem>();
        public static Queue<FoodItem> pendingOrders = new Queue<FoodItem>();
        public static Stack<FoodItem> deliveredOrders = new Stack<FoodItem>();
        public static HashSet<string> foodCategories = new HashSet<string>();


        public static void AddFoodItem()
        {

            Console.Write("Enter the food item's id: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter the food item's name: ");
            string name = Console.ReadLine();

            Console.Write("Enter the food item's price: ");
            double price = double.Parse(Console.ReadLine());

            Console.Write("Enter the food item's category: ");
            string category = Console.ReadLine();


            menu.Add(new FoodItem(id, name, price, category));
            foodCategories.Add(category);

            Console.WriteLine("Order added succesfully in the menu.");

        }

        public static void ShowMenu()
        {
            foreach (var item in menu)
            {
                Console.WriteLine($"Item's ID: {item.ID}, Item Name: {item.Name}, Item Price: {item.Price}, Item Category: {item.Category}");
            }
            Console.WriteLine();
        }

        public static void PlaceOrder()
        {

            while (true)
            {
                Console.WriteLine("Enter the food details for placing your order. \n");

                Console.Write("Enter the food item's id: ");
                int id = int.Parse(Console.ReadLine());

                bool isExist = false;

                if (menu.Count > 0)
                {
                    foreach (var item in menu)
                    {
                        if (item.ID == id)
                        {
                            orders.Add(item.ID, new FoodItem(item.ID, item.Name, item.Price, item.Category));
                            pendingOrders.Enqueue(item);
                            isExist = true;
                        }
                    }

                    if (isExist == true)
                    {
                        Console.WriteLine("Your order is placed!!!");
                    }
                    else
                    {
                        Console.WriteLine("Order with the given id does not exist in the menu!!!");
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("Menu is empty, please wait for a order to be added!!!");
                    break;
                }

            }
        }

        public static void DeliverOrder()
        {
            if (pendingOrders.Count > 0)
            {
                FoodItem food = pendingOrders.Dequeue();
                deliveredOrders.Push(food);
                Console.WriteLine("Order delivered suucessfully!!!");
            }
        }

        public static void ShowPendingDeliveries()
        {
            Console.WriteLine("Pending orders are");
            foreach (var item in pendingOrders)
            {
                Console.WriteLine($"Item'd ID: {item.ID}, Item's name: {item.Name}, Item's price: {item.Price}, Item's category: {item.Category}");
            }
        }

        public static void ShowDeliveredOrders()
        {
            Console.WriteLine("Delivered orders are");
            foreach (var item in deliveredOrders)
            {
                Console.WriteLine($"Item'd ID: {item.ID}, Item's name: {item.Name}, Item's price: {item.Price}, Item's category: {item.Category}");
            }
        }

        public static void ShowFoodCategories()
        {
            if (foodCategories.Count > 0)
            {
                Console.WriteLine("Food categories we have");
                foreach (var item in foodCategories)
                {
                    Console.WriteLine($"{item}");
                }
            }
            else
            {
                Console.WriteLine("No categories are there right now. Please wait for a category to be added");
            }
        }


        static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("Welcome to Online Food Ordering System");
                Console.WriteLine("A. Customer");
                Console.WriteLine("B. Shop Employee");
                Console.WriteLine("E. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                if (choice == "A")
                {
                    Console.WriteLine("1. Show Menu");
                    Console.WriteLine("2. Place Order");
                    Console.WriteLine("3. Show Food Categories");
                    Console.WriteLine("4. Exit");
                    Console.Write("Enter your choice: ");

                    string chc = Console.ReadLine();

                    if (chc == "1")
                    {
                        ShowMenu();
                    }
                    else if (chc == "2")
                    {
                        PlaceOrder();
                    }
                    else if (chc == "3")
                    {
                        ShowFoodCategories();
                    }
                    else if (chc == "4")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Choice, please enter a valid choice");
                    }
                }
                else if (choice == "B")
                {
                    Console.WriteLine("1. Add Food Item");
                    Console.WriteLine("2. Deliver Order");
                    Console.WriteLine("3. Show Pending Deliveries");
                    Console.WriteLine("4. Show Delivered Orders");
                    Console.WriteLine("5. Exit");
                    Console.Write("Enter your choice: ");

                    string chce = Console.ReadLine();

                    if (chce == "1")
                    {
                        AddFoodItem();
                    }
                    else if (chce == "2")
                    {
                        DeliverOrder();
                    }
                    else if (chce == "3")
                    {
                        ShowPendingDeliveries();
                    }
                    else if (chce == "4")
                    {
                        ShowDeliveredOrders();
                    }

                    else if (chce == "5")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice, please enter a valid choice");
                    }
                }
                else if (choice == "E")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Choice, please enter a valid choice");
                }

            }

        }
    }
}





