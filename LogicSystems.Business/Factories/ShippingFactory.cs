using LogicSystems.Business.Shipping;

namespace LogicSystems.Business.Factories
{
    public static class ShippingFactory
    {
        public static IShippingService Create(string type)
        {
            return type switch
            {
                "1" => new ArasAdapter(),
                "2" => new YurtiçiAdapter(),
                _ => throw new Exception("Invalid cargo type")
            };
        }
    }
}