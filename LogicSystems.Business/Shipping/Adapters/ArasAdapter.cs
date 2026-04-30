using System;
using System.Collections.Generic;
using System.Text;

namespace LogicSystems.Business.Shipping
{
    public class ArasAdapter : IShippingService
    {
        private ArasCargoAPI _aras = new ArasCargoAPI();

        public string GenerateTrackingNumber()
        {
            return _aras.CreateTrackingCode();
        }

        public decimal CalculatePrice(double weight)
        {
            return _aras.GetPrice(weight);
        }
    }
}
