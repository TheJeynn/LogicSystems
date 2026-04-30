using System;
using System.Collections.Generic;
using System.Text;

namespace LogicSystems.Business.Shipping.Decorators
{
    public class FragileDecorator : ShippingDecorator
    {
        public FragileDecorator(IShippingService service) : base(service) { }

        public override decimal CalculatePrice(double weight)
        {
            return base.CalculatePrice(weight) + 15;
        }
    }
}
