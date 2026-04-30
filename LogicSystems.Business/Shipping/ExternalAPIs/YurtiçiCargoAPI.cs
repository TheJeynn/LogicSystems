using System;
using System.Collections.Generic;
using System.Text;

namespace LogicSystems.Business.Shipping
{
    public class YurtiçiCargoAPI
    {
        public string TrackingNo()
        {
            return "YURT456";
        }

        public decimal Price(double weight)
        {
            return (decimal)(weight * 12);
        }
    }
}
