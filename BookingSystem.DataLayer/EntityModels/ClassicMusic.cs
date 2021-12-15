using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingSystem.DataLayer.EntityModels
{
    [Table("ClassicMusics")]
    public class ClassicMusic : ArtEvent
    {
        //[Key]
        //public int IdClassicMusic { get; set; }
        public string Voice { get; set; }
        public string ConcertName { get; set; }

    }
}
