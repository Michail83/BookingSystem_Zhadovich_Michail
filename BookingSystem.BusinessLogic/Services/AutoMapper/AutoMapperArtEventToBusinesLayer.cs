using AutoMapper;
using BookingSystem.BusinessLogic.BusinesLogicModels;
using BookingSystem.BusinessLogic.Interfaces;
using BookingSystem.DataLayer.EntityModels;

namespace BookingSystem.BusinessLogic.Services.AutoMapper
{
    public class AutoMapperArtEventToBusinesLayer : IMapper<ArtEvent, ArtEventBL>
    {
        private readonly IMapper _mapper;

        public AutoMapperArtEventToBusinesLayer(IMapper mapper)
        {
            _mapper = mapper;
        }
        public ArtEventBL Map(ArtEvent incoming)
        {
            return _mapper.Map<ArtEventBL>(incoming);
        }
    }
}
