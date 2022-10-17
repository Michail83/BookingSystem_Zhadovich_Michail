using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.BusinessLogic.BusinesLogicModels.PayPalModels
{
    internal class PayPal_Breakdown
    {
        public PayPal_Item_total Item_total { get; set; } = new();
    }
}
