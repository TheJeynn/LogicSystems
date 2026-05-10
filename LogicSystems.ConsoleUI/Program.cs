using LogicSystems.Business;
using LogicSystems.Business.Factories;
using LogicSystems.Business.Observer;
using LogicSystems.Business.Shipping.Decorators;
using LogicSystems.Business.States;
using LogicSystems.Core;
using LogicSystems.Data;
using System;

namespace LogicSystems
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var currentUser = new User
            {
                Id = 1,
                Name = "Burak",
                Email = "burak@test.com",
                Role = UserRole.Admin
            };

            while (true)
            {
                Console.Clear();
                PrintHeader();

                Console.WriteLine("1 - Payment");
                Console.WriteLine("2 - Order");
                Console.WriteLine("3 - Cargo");

                if (currentUser.Role == UserRole.Admin)
                {
                    Console.WriteLine("4 - Products");
                    Console.WriteLine("5 - Stock Test");
                }

                Console.WriteLine("0 - Exit");

                Console.Write("\nSelect Operation: ");
                var mainChoice = Console.ReadLine();

                switch (mainChoice)
                {
                    case "1":
                        HandlePayment();
                        break;

                    case "2":
                        HandleOrder();
                        break;

                    case "3":
                        HandleCargo();
                        break;

                    case "4":

                        if (currentUser.Role == UserRole.Admin)
                        {
                            HandleProducts();
                        }
                        else
                        {
                            Console.WriteLine("Access denied!");
                            Pause();
                        }

                        break;

                    case "5":

                        if (currentUser.Role == UserRole.Admin)
                        {
                            HandleStock();
                        }
                        else
                        {
                            Console.WriteLine("Access denied!");
                            Pause();
                        }

                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Invalid choice!");
                        Pause();
                        break;
                }
            }
        }

        static void HandlePayment()
        {
            Console.Clear();
            PrintHeader();

            Console.WriteLine("PAYMENT");
            Console.WriteLine("1 - Credit Card");
            Console.WriteLine("2 - Bank Transfer");

            Console.Write("\nSelect Payment Method: ");
            var choice = Console.ReadLine() ?? "";

            try
            {
                var payment = PaymentFactory.CreatePayment(choice);

                payment.Pay(1000);

                Logger.GetInstance().Log("Payment completed");
            }
            catch
            {
                Console.WriteLine("Invalid payment type!");
            }

            Pause();
        }

        static void HandleOrder()
        {
            Console.Clear();
            PrintHeader();

            Console.WriteLine("ORDER PROCESS\n");

            var order = new OrderContext(new PendingState());

            Console.WriteLine("Current State: Pending");

            order.Next();
            Console.WriteLine("Order Approved");

            order.Next();
            Console.WriteLine("Order Preparing");

            order.Next();
            Console.WriteLine("Order Shipped");

            order.Next();
            Console.WriteLine("Order Delivered");

            Logger.GetInstance().Log("Order processed");

            Pause();
        }

        static void HandleCargo()
        {
            Console.Clear();
            PrintHeader();

            Console.WriteLine("CARGO SERVICE");
            Console.WriteLine("1 - Aras");
            Console.WriteLine("2 - Yurtiçi");
            Console.WriteLine("3 - GlobalExpress");

            Console.Write("\nSelect Cargo Company: ");

            var cargoChoice = Console.ReadLine() ?? "";

            try
            {
                var shipping = ShippingFactory.Create(cargoChoice);

                Console.Write("Add Insurance? (y/n): ");

                if (Console.ReadLine()?.ToLower() == "y")
                {
                    shipping = new InsuranceDecorator(shipping);
                }

                Console.Write("Add Fragile Protection? (y/n): ");

                if (Console.ReadLine()?.ToLower() == "y")
                {
                    shipping = new FragileDecorator(shipping);
                }

                Console.WriteLine("\n--- Cargo Info ---");

                Console.WriteLine(
                    "Tracking: " +
                    shipping.GenerateTrackingNumber()
                );

                Console.WriteLine(
                    "Price: " +
                    shipping.CalculatePrice(5)
                );

                Logger.GetInstance().Log("Cargo processed");
            }
            catch
            {
                Console.WriteLine("Invalid cargo selection!");
            }

            Pause();
        }

        static void HandleProducts()
        {
            Console.Clear();
            PrintHeader();

            Console.WriteLine("PRODUCT LIST\n");

            var repo = new ProductRepository();

            var products = repo.GetAll();

            foreach (var product in products)
            {
                product.Display();
            }

            Pause();
        }

        static void HandleStock()
        {
            Console.Clear();
            PrintHeader();

            Console.WriteLine("STOCK NOTIFICATION TEST\n");

            var stockManager = new StockManager();

            stockManager.AddObserver(
                new EmailNotifier()
            );

            stockManager.SetStock(5);

            Logger.GetInstance().Log(
                "Stock notification triggered"
            );

            Pause();
        }

        static void PrintHeader()
        {
            Console.WriteLine("===================================");
            Console.WriteLine("     LOGIC SYSTEMS APPLICATION     ");
            Console.WriteLine("===================================\n");
        }

        static void Pause()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}