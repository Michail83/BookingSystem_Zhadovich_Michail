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
