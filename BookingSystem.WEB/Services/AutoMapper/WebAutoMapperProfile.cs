using AutoMapper;
using BookingSystem.BusinessLogic.BusinesLogicModels;
using BookingSystem.WEB.Models;
using Microsoft.AspNetCore.Http;
using System;
using BookingSystem.WEB.StaticClasses;
using System.Threading.Tasks;
using BookingSystem.Infrastructure.Models;

namespace BookingSystem.WEB.Services.AutoMapper
{
    public class WebAutoMapperProfile : Profile
    {
        public WebAutoMapperProfile()
        {
            CreateMap<ArtEventBL, ArtEventViewModel>()
                .ForMember(dest=>dest.Image, source => source.MapFrom(src => Convert.ToBase64String(src.Image??new byte[0]) ))

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


            CreateMap<IncomingBaseCreateArtEventViewModel, ArtEventBL>().
                ForMember(dest => dest.Image, source => source.MapFrom(src => src.Image.ToByteArrayWithResize(640, 480)))
                .Include<IncomingOpenAirCreateViewModel, OpenAirBL>()
                .Include<IncomingPartyCreateViewModel, PartyBL>()
                .Include<IncomingClassicMusicCreateViewModel, ClassicMusicBL>();


            CreateMap<IncomingOpenAirCreateViewModel, OpenAirBL>();
            CreateMap<IncomingPartyCreateViewModel, PartyBL>();
            CreateMap<IncomingClassicMusicCreateViewModel, ClassicMusicBL>();
            CreateMap<User, UserViewModel>();

        }
    }

    //public static class IFormFileConverter
    //{
    //    public static byte[] ToByteArray(this IFormFile formFile) 
    //    {
    //        if (formFile == null)
    //        {
    //            return new byte[0];
    //        }
    //        byte[] imageData = null; 
    //        var memoryStream = new System.IO.MemoryStream();
    //        formFile.CopyTo(memoryStream);
    //        imageData = memoryStream.ToArray();

    //        return imageData;
    //    }
    //}
}
