using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.BusinessLogic.BusinesLogicModels.PayPalModels
{
    internal class PayPal_Amount
    {
        public string Currency_code { get; set; }
        public decimal Value { get; set; }
        public PayPal_Breakdown Breakdown { get; set; } = new();
    }
}                          