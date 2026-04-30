using LogicSystems.Business.Shipping;
using LogicSystems.Business.Shipping.Decorators;

namespace LogicSystems.Business
{
    public class CargoService
    {
        public void ProcessCargo()
        {
            IShippingService shipping = new ArasAdapter();

            shipping = new InsuranceDecorator(shipping);
            shipping = new FragileDecorator(shipping);

            var tracking = shipping.GenerateTrackingNumber();
            var price = shipping.CalculatePrice(5);

            Console.WriteLine($"Tracking: {tracking}");
            Console.WriteLine($"Price: {price}");
        }
    }
}