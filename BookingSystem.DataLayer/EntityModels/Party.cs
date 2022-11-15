using System.ComponentModel.DataAnnotations.Schema;


namespace BookingSystem.DataLayer.EntityModels
{
    [Table("Parties")]
    public class Party : ArtEvent
    {
        public int AgeLimitation { get; set; }
    }
}
