using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingSystem.BusinessLogic.BusinesLogicModels
{

    public class CartWithQuantityBL
    {
        public int Quantity { get; set; }
        public ArtEventBL ArtEventBL { get; set; }
    }
}
