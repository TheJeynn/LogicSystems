using System;
using System.Collections.Generic;
using System.Text;

namespace LogicSystems.Business.Shipping
{
    internal class ArasCargoAPI
    {
        public string CreateTrackingCode()
        {
            return "ARAS123";
        }

        public decimal GetPrice(double kg)
        {
            return (decimal)(kg * 10);
        }
    }
}
