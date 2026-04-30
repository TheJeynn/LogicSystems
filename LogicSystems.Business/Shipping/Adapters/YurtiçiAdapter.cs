using System;
using System.Collections.Generic;
using System.Text;

namespace LogicSystems.Business.Shipping
{
    public class YurtiçiAdapter : IShippingService
    {
        private YurtiçiCargoAPI _api = new YurtiçiCargoAPI();

        public string GenerateTrackingNumber()
        {
            return _api.TrackingNo();
        }

        public decimal CalculatePrice(double weight)
        {
            return _api.Price(weight);
        }
    }
}
