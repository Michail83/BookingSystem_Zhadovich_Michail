using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.BusinessLogic.BusinesLogicModels.PayPalModels
{
    internal class PayPal_Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public PayPal_Unit_amount Unit_amount { get; set; } = new();        
    }
}
