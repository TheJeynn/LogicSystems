using LogicSystems.Business.Strategies;

namespace LogicSystems.Business.Factories
{
    public static class PaymentFactory
    {
        public static IPaymentStrategy CreatePayment(string type)
        {
            return type switch
            {
                "1" => new CreditCardPayment(),
                "2" => new BankTransferPayment(),
                _ => throw new Exception("Invalid payment type")
            };
        }
    }
}