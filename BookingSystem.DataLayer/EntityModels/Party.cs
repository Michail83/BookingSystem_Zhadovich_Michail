using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BookingSystem.DataLayer.EntityModels
{
    [Table("Parties")]
    public class Party : ArtEvent
    {
        //[Key]
        //public int IdParty { get; set; }
        public int AgeLimitation { get; set; }
    }
}
