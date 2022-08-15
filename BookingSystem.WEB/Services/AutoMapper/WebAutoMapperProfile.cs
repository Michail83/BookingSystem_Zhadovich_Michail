using AutoMapper;
using BookingSystem.BusinessLogic.BusinesLogicModels;
using BookingSystem.WEB.Models;




namespace BookingSystem.WEB.Services.AutoMapper
{
    public class WebAutoMapperProfile : Profile
    {
        public WebAutoMapperProfile()
        {
            CreateMap<ArtEventBL, ArtEventViewModel>()
                .Include<PartyBL, ArtEventViewModel>()
                .Include<OpenAirBL, ArtEventViewModel>()
                .Include<ClassicMusicBL, ArtEventViewModel>();
            CreateMap<PartyBL, ArtEventViewModel>()
                .ForMember(dest => dest.AdditionalInfo, source => source.MapFrom(src => new string[] { src.AgeLimitation.ToString() }))
                .ForMember(dest => dest.TypeOfArtEvent, source => source.MapFrom(src => "Party"));

            CreateMap<OpenAirBL, ArtEventViewModel>()
                .ForMember(dest => dest.AdditionalInfo, source => source.MapFrom(src => new string[] { src.HeadLiner }))
                .ForMember(dest => dest.TypeOfArtEvent, source => source.MapFrom(src => "OpenAir"));

            CreateMap<ClassicMusicBL, ArtEventViewModel>()
                .ForMember(dest => dest.AdditionalInfo, source => source.MapFrom(src => new string[] { src.ConcertName, src.Voice }))
                .ForMember(dest => dest.TypeOfArtEvent, source => source.MapFrom(src => "ClassicMusic"));

            CreateMap<CartWithQuantityBL, CartWithQuantityViewModel>()
                .ForMember(dest => dest.ArtEventViewModel, sourse => sourse.MapFrom(src => src.ArtEventBL));

            CreateMap<OrderBL, OrderViewModel>()
                .ForMember(dest => dest.ListOfReservedEventTickets, sourse => sourse.MapFrom(src => src.ListOfReservedEventTickets));
        }
    }
}
