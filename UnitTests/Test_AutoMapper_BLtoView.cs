using AutoMapper;
using BookingSystem.BusinessLogic.BusinesLogicModels;
using BookingSystem.WEB.Models;
using BookingSystem.WEB.Services;
using BookingSystem.WEB.Services.AutoMapper;
using NUnit.Framework;
using System;
using System.Collections.Generic;


namespace UnitTests
{
    [TestFixture]
    public class Test_AutoMapper_BLtoView
    {
        ArtEventViewModel artEventViewModel;
        PartyBL partyBL;
        OpenAirBL openAirBL;
        ClassicMusicBL classicMusicBL;

        Mapper autoMapper;

        OpenAirBL artEventOpenAirBL;
        PartyBL artEventPartyBL;
        ClassicMusicBL artEventClassicMusicBL;

        OrderBL orderBl;
        OrderViewModel orderViewModel;
        CartWithQuantityBL cartWithQuantityBL;

        public Test_AutoMapper_BLtoView()
        {
            autoMapper = new Mapper(new MapperConfiguration(conf => conf.AddProfile(new WebAutoMapperProfile())));

            partyBL = new PartyBL
            {
                Id = 1,
                EventName = "Fake Макс party",
                AmountOfTickets = 300,
                Date = new DateTime(2022, 09, 25, 22, 00, 00),
                Place = "Беларусь, Минск, проспект Независимости, 73",
                Latitude = 53.922065m,
                Longitude = 27.597050m,
                AgeLimitation = 21
            };
            openAirBL = new OpenAirBL
            {
                Id = 1,
                EventName = "Fake Макс party",
                AmountOfTickets = 300,
                Date = new DateTime(2022, 09, 25, 22, 00, 00),
                Place = "Беларусь, Минск, проспект Независимости, 73",
                Latitude = 53.922065m,
                Longitude = 27.597050m,
                HeadLiner = "bbb"
            };
            artEventViewModel = new ArtEventViewModel
            {
                Id = 1,
                EventName = "Fake Макс party",
                AmountOfTickets = 300,
                Date = new DateTime(2022, 09, 25, 22, 00, 00),
                Place = "Беларусь, Минск, проспект Независимости, 73",
                Latitude = 53.922065m,
                Longitude = 27.597050m,
                TypeOfArtEvent = "OpenAir",
                AdditionalInfo = new string[] { "bbb" }
            };
            classicMusicBL = new ClassicMusicBL
            {
                Id = 1,
                EventName = "Fake Макс party",
                AmountOfTickets = 300,
                Date = new DateTime(2022, 09, 25, 22, 00, 00),
                Place = "Беларусь, Минск, проспект Независимости, 73",
                Latitude = 53.922065m,
                Longitude = 27.597050m,
                Voice = "bas",
                ConcertName = "basss"
            };

            cartWithQuantityBL = new CartWithQuantityBL { Quantity = 5, ArtEventBL = openAirBL };
            var listOfReservedTickets = new List<CartWithQuantityBL>() { cartWithQuantityBL };

            orderBl = new OrderBL
            {
                Id = 1,
                TimeOfCreation = new System.DateTime(0),
                UserEmail = "test@test.com",
                ListOfReservedEventTickets = listOfReservedTickets
            };

            var ListCartwithQuantityViewM =
                new List<CartWithQuantityViewModel> {
                    new CartWithQuantityViewModel { Quantity = 5, ArtEventViewModel = artEventViewModel } };

            orderViewModel = new OrderViewModel
            {
                Id = 1,
                TimeOfCreation = new System.DateTime(0),
                UserEmail = "test@test.com",
                ListOfReservedEventTickets = ListCartwithQuantityViewM
            };
        }

        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void Check_AutoMapperArtEventViewModel_fromClassicMusic()
        {
            var mapper = new AutoMapperBetweenArtEventBLAndArtEventViewModel<ClassicMusicBL, ArtEventViewModel>(autoMapper);
            artEventViewModel = new ArtEventViewModel
            {
                Id = 1,
                EventName = "Fake Макс party",
                AmountOfTickets = 300,
                Date = new DateTime(2022, 09, 25, 22, 00, 00),
                Place = "Беларусь, Минск, проспект Независимости, 73",
                Latitude = 53.922065m,
                Longitude = 27.597050m,
                TypeOfArtEvent = "ClassicMusic",
                AdditionalInfo = new string[] { "basss", "bas" }
            };
            var result = mapper.Map(classicMusicBL);
            Assert.IsTrue(result.IsEqual(artEventViewModel));
        }
        [Test]
        public void Check_AutoMapperArtEventViewModel_fromPartyBL()
        {
            var mapper = new AutoMapperBetweenArtEventBLAndArtEventViewModel<PartyBL, ArtEventViewModel>(autoMapper);

            artEventViewModel = new ArtEventViewModel
            {
                Id = 1,
                EventName = "Fake Макс party",
                AmountOfTickets = 300,
                Date = new DateTime(2022, 09, 25, 22, 00, 00),
                Place = "Беларусь, Минск, проспект Независимости, 73",
                Latitude = 53.922065m,
                Longitude = 27.597050m,
                TypeOfArtEvent = "Party",
                AdditionalInfo = new string[] { "21" }
            };
            var result = mapper.Map(partyBL);
            Assert.IsTrue(result.IsEqual(artEventViewModel));
        }
        [Test]
        public void Check_AutoMapperArtEventViewModel_fromOpenAir()
        {
            var mapper = new AutoMapperBetweenArtEventBLAndArtEventViewModel<OpenAirBL, ArtEventViewModel>(autoMapper);

            artEventViewModel = new ArtEventViewModel
            {
                Id = 1,
                EventName = "Fake Макс party",
                AmountOfTickets = 300,
                Date = new DateTime(2022, 09, 25, 22, 00, 00),
                Place = "Беларусь, Минск, проспект Независимости, 73",
                Latitude = 53.922065m,
                Longitude = 27.597050m,
                TypeOfArtEvent = "OpenAir",
                AdditionalInfo = new string[] { "bbb" }
            };
            var result = mapper.Map(openAirBL);
            Assert.IsTrue(result.IsEqual(artEventViewModel));
        }

        [Test]
        public void Check_AutoMapperOrderViewModel_fromOrderBL()
        {
            var mapper = new AutoMapperBetweenArtEventBLAndArtEventViewModel<OrderBL, OrderViewModel>(autoMapper);

            var result = mapper.Map(orderBl);
            Assert.IsTrue(result.IsEqual(orderViewModel));
        }


    }
}
