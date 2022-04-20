using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingSystem.BusinessLogic.BusinesLogicModels
{

    public class OrderBL
    {
        public int Id { get; set; }
        public string UserEmail { get; set; }
        public DateTime TimeOfCreation { get; set; }
        public List<CartWithQuantityBL> ListOfReservedEventTickets { get; set; }
    }
}
