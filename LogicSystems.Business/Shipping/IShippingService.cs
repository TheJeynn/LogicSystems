using System;
using System.Collections.Generic;
using System.Text;

namespace LogicSystems.Business.Shipping
{
    public interface IShippingService
    {
        string GenerateTrackingNumber();
        decimal CalculatePrice(double weight);
    }
}
