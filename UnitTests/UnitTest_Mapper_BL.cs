//using BookingSystem.BusinessLogic.BusinesLogicModels;
//using BookingSystem.BusinessLogic.Interfaces;
//using BookingSystem.BusinessLogic.Services;
//using BookingSystem.DataLayer.EntityModels;
//using Moq;
//using NUnit.Framework;



//namespace UnitTests
//{
//    [TestFixture]
//    public class UnitTest_Mapper_BL
//    {
        

//        OpenAir artEventOpenAir;
//        OpenAirBL artEventOpenAirBL;
//        Party artEventParty;
//        PartyBL artEventPartyBL;
//        ClassicMusic artEventClassicMusic;
//        ClassicMusicBL artEventClassicMusicBL;

//        Mock<IMapper<Party, PartyBL>> fakeMapperPartyToBusinessLayer = new();
//        Mock<IMapper<OpenAir, OpenAirBL>> fakeOpenAirToBusinessLayer = new();
//        Mock<IMapper<ClassicMusic, ClassicMusicBL>> fakeClassicMusicToBusinessLayer = new();

//        [SetUp]
//        public void Setup()
//        {
           

//            artEventOpenAir = new OpenAir
//            {
//                Id = 15,
//                AmountOfTickets = 15,
//                Date = new System.DateTime(0),
//                EventName = "15",
//                Latitude = 50m,
//                Longitude = 50m,
//                Place = "15",
//                HeadLiner = "15"
//            };
//            artEventOpenAirBL = new OpenAirBL
//            {
//                Id = 15,
//                AmountOfTickets = 15,
//                Date = new System.DateTime(0),
//                EventName = "15",
//                Latitude = 50m,
//                Longitude = 50m,
//                Place = "15",
//                HeadLiner = "15"
//            };
//            artEventParty = new Party
//            {
//                Id = 15,
//                AmountOfTickets = 15,
//                Date = new System.DateTime(0),
//                EventName = "15",
//                Latitude = 50m,
//                Longitude = 50m,
//                Place = "15",
//                AgeLimitation = 15
//            };
//            artEventPartyBL = new PartyBL
//            {
//                Id = 15,
//                AmountOfTickets = 15,
//                Date = new System.DateTime(0),
//                EventName = "15",
//                Latitude = 50m,
//                Longitude = 50m,
//                Place = "15",
//                AgeLimitation = 15
//            };
//            artEventClassicMusic = new ClassicMusic
//            {
//                Id = 15,
//                AmountOfTickets = 15,
//                Date = new System.DateTime(0),
//                EventName = "15",
//                Latitude = 50m,
//                Longitude = 50m,
//                Place = "15",
//                Voice = "bas",
//                ConcertName = "great"


//            };
//            artEventClassicMusicBL = new ClassicMusicBL
//            {
//                Id = 15,
//                AmountOfTickets = 15,
//                Date = new System.DateTime(0),
//                EventName = "15",
//                Latitude = 50m,
//                Longitude = 50m,
//                Place = "15",
//                Voice = "bas",
//                ConcertName = "great"
//            };

//        }
//        #region Check_MapperArtEventToBusinesLayer
//        [Test]
//        public void Check_MapperArtEventToBusinesLayer_IsMapperCalled_OpenAirToOpenAirBL()
//        {
//            mapperArtEventToArtEventBL.Map(artEventOpenAir);
//            fakeOpenAirToBusinessLayer.Verify(mock => mock.Map(artEventOpenAir));
//        }
//        [Test]
//        public void Check_MapperArtEventToBusinesLayer_IsMapperCalled_PartyToPartyBL()
//        {
//            mapperArtEventToArtEventBL.Map(artEventParty);
//            fakeMapperPartyToBusinessLayer.Verify(mock => mock.Map(artEventParty));
//        }
//        [Test]
//        public void Check_MapperArtEventToBusinesLayer_IsMapperCalled_ClassicMusicToClassicMusicBL()
//        {
//            mapperArtEventToArtEventBL.Map(artEventClassicMusic);
//            fakeClassicMusicToBusinessLayer.Verify(mock => mock.Map(artEventClassicMusic));
//        }
//        #endregion Check_MapperArtEventToBusinesLayer

//        #region Check_Mappers_DAL_to_BL
//        [Test]
//        public void Check_MapperPartyToBusinessLayer()
//        {
//            MapperPartyToBusinessLayer mapperPartyToBusinessLayer = new();
//            Assert.IsTrue(mapperPartyToBusinessLayer.Map(artEventParty).IsEqual(artEventPartyBL));
//        }

//        [Test]
//        public void Check_MapperOpenAirToBusinessLayer()
//        {
//            MapperOpenAirToBusinessLayer mapperOpenAirToBusinessLayer = new();
//            Assert.IsTrue(mapperOpenAirToBusinessLayer.Map(artEventOpenAir).IsEqual(artEventOpenAirBL));
//        }
//        [Test]
//        public void Check_MapperClassicMusicToBusinessLayer()
//        {
//            MapperClassicMusicToBusinessLayer mapperClassicMusicToBusinessLayer = new();
//            Assert.IsTrue(mapperClassicMusicToBusinessLayer.Map(artEventClassicMusic).IsEqual(artEventClassicMusicBL));
//        }
//        #endregion Check_Mappers_DAL_to_BL

//        #region Check_Mappers_BL_to_DAL
//        [Test]
//        public void Check_MapperPartyBLtoDALentity()
//        {
//            MapperPartyBLtoDALentity mapperPartyBLtoDALentity = new();
//            Assert.IsTrue(mapperPartyBLtoDALentity.Map(artEventPartyBL).IsEqual(artEventParty));
//        }

//        [Test]
//        public void Check_MapperOpenAirBLtoDALentity()
//        {
//            MapperOpenAirBLtoDALentity mapperOpenAirBLtoDALentity = new();
//            Assert.IsTrue(mapperOpenAirBLtoDALentity.Map(artEventOpenAirBL).IsEqual(artEventOpenAir));
//        }
//        [Test]
//        public void Check_MapperClassicMusicBLtoDALentity()
//        {
//            MapperClassicMusicBLtoDALentity mapperClassicMusicBLtoDALentity = new();
//            Assert.IsTrue(mapperClassicMusicBLtoDALentity.Map(artEventClassicMusicBL).IsEqual(artEventClassicMusic));
//        }
//        #endregion Check_Mappers_BL_to_DAL

//    }


//}
