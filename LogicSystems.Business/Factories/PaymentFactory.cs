using LogicSystems.Business.Strategies;

namespace LogicSystems.Business.Factories
{
    public static class PaymentFactory
    {
        public static IPaymentStrategy CreatePayment(string type)
        {
            return type switch
            {
                "1" => new BankTransferPayment(),
                "2" => new CreditCardPayment(),
                _ => throw new Exception("Invalid payment type")
            };
        }
    }
}