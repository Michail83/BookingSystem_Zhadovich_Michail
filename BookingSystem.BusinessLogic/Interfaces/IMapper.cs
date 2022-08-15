namespace BookingSystem.BusinessLogic.Interfaces
{
    public interface IMapper<Tin, Tout>
    {
        public Tout Map(Tin incoming);
    }
}
