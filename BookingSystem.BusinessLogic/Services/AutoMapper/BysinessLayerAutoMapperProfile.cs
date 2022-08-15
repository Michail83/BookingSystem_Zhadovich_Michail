using AutoMapper;
using BookingSystem.BusinessLogic.BusinesLogicModels;
using BookingSystem.DataLayer.EntityModels;


namespace BookingSystem.BusinessLogic.Services.AutoMapper
{
    public class BysinessLayerAutoMapperProfile : Profile
    {
        public BysinessLayerAutoMapperProfile()
        {
            CreateMap<ArtEvent, ArtEventBL>()
                .Include<OpenAir, OpenAirBL>()
                .Include<Party, PartyBL>()
                .Include<ClassicMusic, ClassicMusicBL>().ReverseMap();

            CreateMap<OpenAir, OpenAirBL>().ReverseMap();
            CreateMap<Party, PartyBL>().ReverseMap();
            CreateMap<ClassicMusic, ClassicMusicBL>().ReverseMap();

            CreateMap<OrderAndArtEvent, CartWithQuantityBL>()
                .ForMember(dest => dest.Quantity, sourse => sourse.MapFrom(src => src.NumberOfBookedTicket))
                .ForMember(dest => dest.ArtEventBL, sourse => sourse.MapFrom(src => src.ArtEvent));

            CreateMap<CartWithQuantityBL, OrderAndArtEvent>()
               .ForMember(dest => dest.NumberOfBookedTicket, sourse => sourse.MapFrom(src => src.Quantity))
               .ForMember(dest => dest.ArtEventId, sourse => sourse.MapFrom(src => src.ArtEventBL.Id))
               .ForMember(dest => dest.ArtEvent, source => source.Ignore());

            CreateMap<Order, OrderBL>()
                .ForMember(dest => dest.ListOfReservedEventTickets, sourse => sourse.MapFrom(src => src.OrderAndArtEvents)).ReverseMap();




        }

    }
}
