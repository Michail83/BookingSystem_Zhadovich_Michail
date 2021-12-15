using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingSystem.DataLayer.EntityModels
{
    [Table("OpenAirs")]
    public class OpenAir : ArtEvent
    {
        //[Key]
        //public int IdOpenAir { get; set; }
        public string HeadLiner { get; set; }
    }
}
