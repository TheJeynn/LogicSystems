using Xunit;
using LogicSystems.Business.Factories;
using LogicSystems.Business.Shipping;
using LogicSystems.Business.Shipping.Decorators;

namespace LogicSystems.Tests
{
    public class ShippingTests
    {
        [Fact]
        public void ShippingFactory_ShouldReturnArasAdapter()
        {
            var shipping = ShippingFactory.Create("1");

            Assert.IsType<ArasAdapter>(shipping);
        }

        [Fact]
        public void ShippingFactory_ShouldReturnYurticiAdapter()
        {
            var shipping = ShippingFactory.Create("2");

            Assert.IsType<YurtiçiAdapter>(shipping);
        }

        [Fact]
        public void InsuranceDecorator_ShouldIncreasePrice()
        {
            IShippingService shipping = new ArasAdapter();

            var normalPrice = shipping.CalculatePrice(5);

            shipping = new InsuranceDecorator(shipping);

            var insuredPrice = shipping.CalculatePrice(5);

            Assert.True(insuredPrice > normalPrice);
        }

        [Fact]
        public void FragileDecorator_ShouldIncreasePrice()
        {
            IShippingService shipping = new ArasAdapter();

            var normalPrice = shipping.CalculatePrice(5);

            shipping = new FragileDecorator(shipping);

            var fragilePrice = shipping.CalculatePrice(5);

            Assert.True(fragilePrice > normalPrice);
        }
    }
}