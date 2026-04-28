using LogicSystems.Business.Factories;
using LogicSystems.Business.Strategies;

Console.WriteLine("1 - Credit Card");
Console.WriteLine("2 - Bank Transfer");

var choice = Console.ReadLine();

var payment = PaymentFactory.CreatePayment(choice);

payment.Pay(1000);