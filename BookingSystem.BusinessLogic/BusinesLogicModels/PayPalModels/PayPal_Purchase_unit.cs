using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.BusinessLogic.BusinesLogicModels.PayPalModels
{
    internal class PayPal_Purchase_unit
    {
        public List<PayPal_Item> Items { get; set; }=new ();
        public PayPal_Amount Amount { get; set; } = new ();
        public string Custom_id { get; set; }

    }
}
