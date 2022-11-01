//using BookingSystem.BusinessLogic.BusinesLogicModels;
//using BookingSystem.BusinessLogic.Interfaces;
//using BookingSystem.BusinessLogic.Services;
//using BookingSystem.DataLayer.EntityModels;
//using BookingSystem.DataLayer.Interfaces;
//using Moq;
//using NUnit.Framework;
//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace UnitTests
//{
//    [TestFixture]
//    internal class UnitTest_ArtEventBLService
//    {
//        ArtEventBLService artEventBLService;

//        Mock<IRepositoryAsync<ArtEvent>> fakeArtEventRepository = new();
//        Mock<IMapper<ArtEvent, ArtEventBL>> FakeMapperToBL = new();
//        Mock<IArtEventFilter<ArtEvent>> FakeArtEventFilter = new();
//        Mock<IArtEventSort<ArtEvent>> FakeArtEventSorter = new();

//        Party party = new Party
//        {
//            Id = 6,
//            EventName = "Fake TNT Party",
//            AgeLimitation = 18,
//            AmountOfTickets = 1500,
//            Date = new DateTime(2022, 10, 31, 19, 0, 0),
//            Place = "Беларусь, Минск, Революционная улица, 9А",
//            Latitude = 53.902375271214524m,
//            Longitude = 27.55158689814755m
//        };
//        OpenAir openAir = new OpenAir
//        {
//            Id = 3,
//            EventName = "Fake Gorky Party",
//            AmountOfTickets = 1000,
//            Date = new DateTime(2022, 12, 31, 15, 0, 0),
//            Place = "Беларусь, Минск, Первомайская улица, 3А",
//            Latitude = 53.90222207800099m,
//            Longitude = 27.57284678552759m,
//            HeadLiner = "The Best Headliner",

//        };
//        ClassicMusic classicMusic = new ClassicMusic
//        {
//            Id = 4,
//            EventName = "Fake classic musik  1",
//            ConcertName = "classic musik  1",
//            AmountOfTickets = 200,
//            Date = new DateTime(2022, 07, 23, 16, 0, 0),
//            Voice = "tenor",
//            Place = "Беларусь, Минск, проспект Независимости, 50",
//            Latitude = 53.91486434449279m,
//            Longitude = 27.584181354972173m,
//        };

//        List<ArtEvent> fakeArtEventsList;

//        IQueryable<ArtEvent> fakeArtEvents;

//        public UnitTest_ArtEventBLService()
//        {
//            fakeArtEventsList = new List<ArtEvent> { party, openAir, classicMusic };
//            fakeArtEvents = fakeArtEventsList.AsQueryable();

//            fakeArtEventRepository.Setup(repository => repository.GetAll()).Returns(fakeArtEvents);

//        }


//        [TestCase("classicmusic", "", 2, TestName = "FilterForArtEvent_byType_ClassicMusic")]
//        [TestCase("openair", "", 1, TestName = "FilterForArtEvent_byType_OpenAir")]
//        [TestCase("party", "", 0, TestName = "FilterForArtEvent_byType_Party")]

//        [TestCase("", "Fake classic", 2, TestName = "FilterForArtEvent byName Fake classic")]
//        [TestCase("", "Fake Gorky P", 1, TestName = "FilterForArtEvent_byName Fake Gorky P")]
//        [TestCase("", "Fake TNT", 0, TestName = "FilterForArtEvent_byName Fake TNT")]

//        [TestCase(null, null, 0, TestName = "FilterForArtEvent_null")]

//        public void FilterForArtEvent(string filterByType, string filterName, int indexOfFirstExpected)
//        {
//            FilterForArtEvent filterForArtEvent = new();
//            var pageState = new PagesState { TypeForFilter = filterByType, NameForFilter = filterName };

//            var filterResult = filterForArtEvent.FilterBy(fakeArtEvents, pageState).ToList();

//            Assert.IsTrue(filterResult[0].IsEqual(fakeArtEventsList[indexOfFirstExpected]));

//        }

//        [TestCase("AmountOfTickets", 2, TestName = "SortForArtEvent => AmountOfTickets ")]
//        [TestCase("AmountOfTickets desc", 0, TestName = "SortForArtEvent => AmountOfTickets DESC ")]
//        [TestCase(" ", 1, TestName = "SortForArtEvent => WhiteSpace ")]
//        [TestCase("Blablabal ", 1, TestName = "SortForArtEvent => wrong string ")]

//        public void SortForArtEvent(string sortBy, int indexOfresult)
//        {
//            SortForArtEvent<ArtEvent> sortForArtEvent = new();

//            var resultOfSort = sortForArtEvent.SortBy(fakeArtEvents, sortBy).ToList();

//            Assert.IsTrue(resultOfSort[0].IsEqual(fakeArtEventsList[indexOfresult]));
//        }






//        //    private IQueryable<ArtEvent> GetFakeArtEvents()
//        //{
//        //    var party = new Party
//        //    {
//        //        Id = 6,
//        //        EventName = "Fake TNT Party",
//        //        AgeLimitation = 18,
//        //        AmountOfTickets = 1500,
//        //        Date = new DateTime(2022, 10, 31, 19, 0, 0),
//        //        Place = "Беларусь, Минск, Революционная улица, 9А",
//        //        Latitude = 53.902375271214524m,
//        //        Longitude = 27.55158689814755m
//        //    };
//        //    var openAir = new OpenAir
//        //    {
//        //        Id = 3,
//        //        EventName = "Fake Gorky Party",
//        //        AmountOfTickets = 1500,
//        //        Date = new DateTime(2022, 12, 31, 15, 0, 0),
//        //        Place = "Беларусь, Минск, Первомайская улица, 3А",
//        //        Latitude = 53.90222207800099m,
//        //        Longitude = 27.57284678552759m,
//        //        HeadLiner = "The Best Headliner",

//        //    };
//        //    var classicMusic = new ClassicMusic
//        //    {
//        //        Id = 4,
//        //        EventName = "Fake classic musik  1",
//        //        ConcertName = "classic musik  1",
//        //        AmountOfTickets = 200,
//        //        Date = new DateTime(2022, 07, 23, 16, 0, 0),
//        //        Voice = "tenor",
//        //        Place = "Беларусь, Минск, проспект Независимости, 50",
//        //        Latitude = 53.91486434449279m,
//        //        Longitude = 27.584181354972173m,
//        //    };
//        //    IQueryable<ArtEvent> result =  (IQueryable<ArtEvent>) new List<ArtEvent> { party, openAir, classicMusic};

//        //    return (IQueryable<ArtEvent>)result;
//        //}



//    }
//}
