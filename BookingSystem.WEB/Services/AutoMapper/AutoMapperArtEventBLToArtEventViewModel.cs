using AutoMapper;
using BookingSystem.BusinessLogic.Interfaces;

namespace BookingSystem.WEB.Services

{
    //public class AutoMapperArtEventBLToArtEventViewModel : IMapper<ArtEventBL, ArtEventViewModel>
    //{
    //    IMapper _mapper;

    //    public AutoMapperArtEventBLToArtEventViewModel(IMapper mapper) 
    //    {
    //        _mapper = mapper;
    //    }
    //    public ArtEventViewModel Map(ArtEventBL artEventBL)
    //    { 
    //        return  _mapper.Map<ArtEventViewModel>(artEventBL);
    //    }
    //}
    public class AutoMapperArtEventBLToArtEventViewModel<Tin, Tout> : IMapper<Tin, Tout>
    {
        IMapper _mapper;

        public AutoMapperArtEventBLToArtEventViewModel(IMapper mapper)
        {
            _mapper = mapper;
        }
        public Tout Map(Tin item)
        {
            return _mapper.Map<Tout>(item);
        }
    }
}
