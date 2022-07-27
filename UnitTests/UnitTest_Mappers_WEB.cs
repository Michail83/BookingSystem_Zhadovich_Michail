using BookingSystem.BusinessLogic.BusinesLogicModels;
using BookingSystem.WEB.Models;
using BookingSystem.WEB.Services;
using BookingSystem.WEB.StaticClasses;
using NUnit.Framework;
using System;


namespace UnitTests
{
    [TestFixture]
    public class UnitTest_Mappers_WEB
    {
        ArtEventViewModel artEventViewModel;
        PartyBL partyBL;
        OpenAirBL openAirBL;
        ClassicMusicBL classicMusicBL;

        MapperFromArtEventBLToArtEventViewModel MapperFromArtEventBLToArtEventViewModel;

        public UnitTest_Mappers_WEB()
        {
            //artEventViewModel = new ArtEventViewModel
            //{
            //    Id = 1,
            //    EventName = "Fake Макс party",
            //    AmountOfTickets = 300,
            //    Date = new DateTime(2022, 09, 25, 22, 00, 00),
            //    Place = "Беларусь, Минск, проспект Независимости, 73",
            //    Latitude = 53.922065m,
            //    Longitude = 27.597050m,
            //    TypeOfArtEvent = "Party",
            //    AdditionalInfo = new string[] { "21" }
            //};

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

            classicMusicBL = new ClassicMusicBL 
            {
                Id = 1,
                EventName = "Fake Макс party",
                AmountOfTickets = 300,
                Date = new DateTime(2022, 09, 25, 22, 00, 00),
                Place = "Беларусь, Минск, проспект Независимости, 73",
                Latitude = 53.922065m,
                Longitude = 27.597050m,
                Voice="bas",
                ConcertName="basss"
            };
        }

        [SetUp]
        public void Setup()
        {

        }
        [Test]
        public void ConvertFromClassicMusicEventBLtoView()
        {
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
            var result = StaticMapperElements.ConvertFromClassicMusicEventBLtoView(classicMusicBL);
            Assert.IsTrue(result.IsEqual(artEventViewModel));

        }
        [Test]
        public void ConvertFromPartyEventBLtoView()
        {
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
            var result = StaticMapperElements.ConvertFromPartyEventBLtoView(partyBL);
            Assert.IsTrue(result.IsEqual(artEventViewModel));

        }
        [Test]
        public void ConvertFromOpenAirEventBLtoView()
        {
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
            var result = StaticMapperElements.ConvertFromOpenAirEventBLtoView(openAirBL);
            Assert.IsTrue(result.IsEqual(artEventViewModel));
        }
    }
}
