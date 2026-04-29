using LogicSystems.Business.Factories;
using LogicSystems.Business.Strategies;
using LogicSystems.Business.States;
using LogicSystems.Business;
using LogicSystems.Data;

Console.WriteLine("Select Payment Method:");
Console.WriteLine("1 - Credit Card");
Console.WriteLine("2 - Bank Transfer");

var choice = Console.ReadLine();

// Factory + Strategy
var payment = PaymentFactory.CreatePayment(choice);

// ödeme
payment.Pay(1000);

// Singleton Logger
Logger.GetInstance().Log("Payment completed");

// State Pattern
var order = new OrderContext(new PendingState());

Console.WriteLine("\nOrder Process:");
order.Next(); // Approved
order.Next(); // Shipped
order.Next(); // Delivered
order.Cancel(); // artık iptal edilemez