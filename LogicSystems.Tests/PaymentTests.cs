using Xunit;
using LogicSystems.Business.Factories;
using LogicSystems.Business.Strategies;

namespace LogicSystems.Tests
{
    public class PaymentTests
    {
        [Fact]
        public void CreatePayment_ShouldReturnCreditCardPayment()
        {
            var payment = PaymentFactory.CreatePayment("1");

            Assert.IsType<CreditCardPayment>(payment);
        }

        [Fact]
        public void CreatePayment_ShouldReturnBankTransferPayment()
        {
            var payment = PaymentFactory.CreatePayment("2");

            Assert.IsType<BankTransferPayment>(payment);
        }

        [Fact]
        public void CreatePayment_InvalidChoice_ShouldThrowException()
        {
            Assert.Throws<Exception>(() =>
            {
                PaymentFactory.CreatePayment("99");
            });
        }
    }
}