using System;
using LogicSystems.Business;
using LogicSystems.Business.Factories;
using LogicSystems.Business.Shipping;
using LogicSystems.Business.Shipping.Decorators;
using LogicSystems.Business.States;
using LogicSystems.Data;

namespace LogicSystems
{
    public class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                PrintHeader();

                Console.WriteLine("1 - Payment");
                Console.WriteLine("2 - Order");
                Console.WriteLine("3 - Cargo");
                Console.WriteLine("4 - Products");
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
                        HandleProducts();
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

            Console.WriteLine("ORDER PROCESS");

            var order = new OrderContext(new PendingState());

            order.Next();
            order.Next();
            order.Next();
            order.Cancel();

            Logger.GetInstance().Log("Order processed");

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

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
        static void HandleCargo()
        {
            Console.Clear();
            PrintHeader();

            Console.WriteLine("CARGO SERVICE");
            Console.WriteLine("1 - Aras");
            Console.WriteLine("2 - Yurtiçi");
            Console.Write("\nSelect Cargo Company: ");
            var cargoChoice = Console.ReadLine() ?? "";

            try
            {
                var shipping = ShippingFactory.Create(cargoChoice);

                Console.Write("Add Insurance? (y/n): ");
                if (Console.ReadLine()?.ToLower() == "y")
                    shipping = new InsuranceDecorator(shipping);

                Console.Write("Add Fragile Protection? (y/n): ");
                if (Console.ReadLine()?.ToLower() == "y")
                    shipping = new FragileDecorator(shipping);

                Console.WriteLine("\n--- Cargo Info ---");
                Console.WriteLine("Tracking: " + shipping.GenerateTrackingNumber());
                Console.WriteLine("Price: " + shipping.CalculatePrice(5));

                Logger.GetInstance().Log("Cargo processed");
            }
            catch
            {
                Console.WriteLine("Invalid cargo selection!");
            }

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