using System;
using System.Collections.Generic;
using System.Text;

namespace LogicSystems.Business.Shipping.Decorators
{
    public class InsuranceDecorator : ShippingDecorator
    {
        public InsuranceDecorator(IShippingService service) : base(service) { }

        public override decimal CalculatePrice(double weight)
        {
            return base.CalculatePrice(weight) + 20;
        }
    }
}
