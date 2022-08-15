using AutoMapper;
using BookingSystem.BusinessLogic.Interfaces;

namespace BookingSystem.BusinessLogic.Services.AutoMapper
{
    public class AutoMapperBetweenDLandBLlayer<FromType, ToType> : IMapper<FromType, ToType>
    {
        private readonly IMapper _mapper;
        public AutoMapperBetweenDLandBLlayer(IMapper mapper)
        {
            _mapper = mapper;
        }

        public ToType Map(FromType incoming)
        {
            return _mapper.Map<ToType>(incoming);
        }
    }
}
