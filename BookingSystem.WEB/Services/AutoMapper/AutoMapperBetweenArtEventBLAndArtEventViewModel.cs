using AutoMapper;
using BookingSystem.BusinessLogic.Interfaces;

namespace BookingSystem.WEB.Services
{
    public class AutoMapperBetweenArtEventBLAndArtEventViewModel<Tin, Tout> : IMapper<Tin, Tout>
    {
        IMapper _mapper;

        public AutoMapperBetweenArtEventBLAndArtEventViewModel(IMapper mapper)
        {
            _mapper = mapper;
        }
        public Tout Map(Tin item)
        {
            return _mapper.Map<Tout>(item);
        }
    }
}
