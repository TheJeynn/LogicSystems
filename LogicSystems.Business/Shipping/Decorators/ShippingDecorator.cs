using System;
using System.Collections.Generic;
using System.Text;

namespace LogicSystems.Business.Shipping.Decorators
{
    public abstract class ShippingDecorator : IShippingService
    {
        protected IShippingService _service;

        public ShippingDecorator(IShippingService service)
        {
            _service = service;
        }

        public virtual string GenerateTrackingNumber()
        {
            return _service.GenerateTrackingNumber();
        }

        public virtual decimal CalculatePrice(double weight)
        {
            return _service.CalculatePrice(weight);
        }
    }
}
