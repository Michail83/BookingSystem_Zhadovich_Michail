using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.BusinessLogic.BusinesLogicModels.PayPalModels
{
    internal class PayPal_CreatedRequest
    {
        public string Intent { get; set; }
        public List<PayPal_Purchase_unit> Purchase_units { get; set; } = new();
    }
}
