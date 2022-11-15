//using AutoMapper;
//using BookingSystem.BusinessLogic.BusinesLogicModels;
//using BookingSystem.BusinessLogic.Interfaces;
//using BookingSystem.BusinessLogic.Services.AutoMapper;
//using BookingSystem.DataLayer.EntityModels;
//using Moq;
//using NUnit.Framework;

//namespace UnitTests
//{
//    [TestFixture]
//    public class AutoMapper_BetweenDLandBL
//    {
//        readonly Mapper _mapper;

//        AutoMapperArtEventToBusinesLayer mapperArtEventToArtEventBL;

//        public AutoMapper_BetweenDLandBL()
//        {
//            _mapper = new Mapper(new MapperConfiguration(conf => conf.AddProfile<BysinessLayerAutoMapperProfile>()));
//            mapperArtEventToArtEventBL = new AutoMapperArtEventToBusinesLayer(_mapper);
//        }
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
//        public void Check_AuroMapperArtEventToBusinesLayer_OpenAirToOpenAirBL()
//        {
//            Assert.IsTrue(mapperArtEventToArtEventBL.Map(artEventOpenAir).IsEqual(artEventOpenAirBL));

//        }
//        [Test]
//        public void Check_AutoMapperArtEventToBusinesLayer_PartyToPartyBL()
//        {
//            Assert.IsTrue(mapperArtEventToArtEventBL.Map(artEventParty).IsEqual(artEventPartyBL));
//        }
//        [Test]
//        public void Check_AutoMapperArtEventToBusinesLayer_ClassicMusicToClassicMusicBL()
//        {
//            Assert.IsTrue(mapperArtEventToArtEventBL.Map(artEventClassicMusic).IsEqual(artEventClassicMusicBL));
//        }
//        #endregion Check_MapperArtEventToBusinesLayer

//        #region Check_Mappers_DAL_to_BL
//        [Test]
//        public void Check_MapperPartyToBusinessLayer()
//        {

//            AutoMapperBetweenDLandBLlayer<Party, PartyBL> mapperPartyToBusinessLayer
//                = new AutoMapperBetweenDLandBLlayer<Party, PartyBL>(new AutoMapper.Mapper(
//                    new MapperConfiguration(conf => conf.AddProfile<BysinessLayerAutoMapperProfile>())));

//            Assert.IsTrue(mapperPartyToBusinessLayer.Map(artEventParty).IsEqual(artEventPartyBL));
//        }

//        [Test]
//        public void Check_MapperOpenAirToBusinessLayer()
//        {
//            AutoMapperBetweenDLandBLlayer<OpenAir, OpenAirBL> mapperOpenAirToBusinessLayer
//                = new AutoMapperBetweenDLandBLlayer<OpenAir, OpenAirBL>(new Mapper(
//                    new MapperConfiguration(conf => conf.AddProfile<BysinessLayerAutoMapperProfile>()
//                    )));
//            Assert.IsTrue(mapperOpenAirToBusinessLayer.Map(artEventOpenAir).IsEqual(artEventOpenAirBL));
//        }
//        [Test]
//        public void Check_MapperClassicMusicToBusinessLayer()
//        {
//            AutoMapperBetweenDLandBLlayer<ClassicMusic, ClassicMusicBL> mapperClassicMusicToBusinessLayer
//                = new AutoMapperBetweenDLandBLlayer<ClassicMusic, ClassicMusicBL>(new AutoMapper.Mapper(
//                    new MapperConfiguration(conf => conf.AddProfile<BysinessLayerAutoMapperProfile>()
//                    )));
//            Assert.IsTrue(mapperClassicMusicToBusinessLayer.Map(artEventClassicMusic).IsEqual(artEventClassicMusicBL));
//        }
//        #endregion Check_Mappers_DAL_to_BL

//        #region Check_Mappers_BL_to_DAL
//        [Test]
//        public void Check_MapperPartyBLtoDALentity()
//        {
//            AutoMapperBetweenDLandBLlayer<PartyBL, Party> mapperPartyBLtoDALentity
//                = new AutoMapperBetweenDLandBLlayer<PartyBL, Party>(new AutoMapper.Mapper(
//                    new MapperConfiguration(conf => conf.CreateMap<PartyBL, Party>()
//                    )));
//            Assert.IsTrue(mapperPartyBLtoDALentity.Map(artEventPartyBL).IsEqual(artEventParty));
//        }

//        [Test]
//        public void Check_MapperOpenAirBLtoDALentity()
//        {
//            AutoMapperBetweenDLandBLlayer<OpenAirBL, OpenAir> mapperOpenAirBLtoDALentity
//                = new AutoMapperBetweenDLandBLlayer<OpenAirBL, OpenAir>(
//                    new AutoMapper.Mapper(
//                    new MapperConfiguration(conf => conf.AddProfile(new BysinessLayerAutoMapperProfile()))));

//            Assert.IsTrue(mapperOpenAirBLtoDALentity.Map(artEventOpenAirBL).IsEqual(artEventOpenAir));
//        }
//        [Test]
//        public void Check_MapperClassicMusicBLtoDALentity()
//        {
//            AutoMapperBetweenDLandBLlayer<ClassicMusicBL, ClassicMusic> mapperClassicMusicBLtoDALentity
//                = new AutoMapperBetweenDLandBLlayer<ClassicMusicBL, ClassicMusic>(
//                    new AutoMapper.Mapper(

//                        new MapperConfiguration(conf => conf.AddProfile(new BysinessLayerAutoMapperProfile()))));

//            Assert.IsTrue(mapperClassicMusicBLtoDALentity.Map(artEventClassicMusicBL).IsEqual(artEventClassicMusic));
//        }
//        #endregion Check_Mappers_BL_to_DAL

//    }
//}
