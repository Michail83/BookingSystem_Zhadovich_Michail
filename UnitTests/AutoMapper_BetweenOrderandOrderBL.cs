using AutoMapper;
using BookingSystem.BusinessLogic.BusinesLogicModels;
using BookingSystem.BusinessLogic.Services.AutoMapper;
using BookingSystem.DataLayer.EntityModels;
using NUnit.Framework;
using System.Collections.Generic;

namespace UnitTests
{
    [TestFixture]
    public class AutoMapper_BetweenOrderandOrderBL
    {
        readonly Mapper _mapper;

        AutoMapperArtEventToBusinesLayer mapperArtEventToArtEventBL;


        OpenAir artEventOpenAir;
        OpenAirBL artEventOpenAirBL;
        Party artEventParty;
        PartyBL artEventPartyBL;
        ClassicMusic artEventClassicMusic;
        ClassicMusicBL artEventClassicMusicBL;

        Order order;
        Order orderFromDALtoBL;
        OrderBL orderBl;
        OrderAndArtEvent orderAndArtEvent;
        OrderAndArtEvent orderAndArtEventFromDALtoBL;
        CartWithQuantityBL cartWithQuantityBL;

        public AutoMapper_BetweenOrderandOrderBL()
        {
            artEventOpenAir = new OpenAir
            {
                Id = 15,
                AmountOfTickets = 15,
                Date = new System.DateTime(0),
                EventName = "15",
                Latitude = 50m,
                Longitude = 50m,
                Place = "15",
                HeadLiner = "15"
            };
            artEventOpenAirBL = new OpenAirBL
            {
                Id = 15,
                AmountOfTickets = 15,
                Date = new System.DateTime(0),
                EventName = "15",
                Latitude = 50m,
                Longitude = 50m,
                Place = "15",
                HeadLiner = "15"
            };
            artEventParty = new Party
            {
                Id = 15,
                AmountOfTickets = 15,
                Date = new System.DateTime(0),
                EventName = "15",
                Latitude = 50m,
                Longitude = 50m,
                Place = "15",
                AgeLimitation = 15
            };
            artEventPartyBL = new PartyBL
            {
                Id = 15,
                AmountOfTickets = 15,
                Date = new System.DateTime(0),
                EventName = "15",
                Latitude = 50m,
                Longitude = 50m,
                Place = "15",
                AgeLimitation = 15
            };
            artEventClassicMusic = new ClassicMusic
            {
                Id = 15,
                AmountOfTickets = 15,
                Date = new System.DateTime(0),
                EventName = "15",
                Latitude = 50m,
                Longitude = 50m,
                Place = "15",
                Voice = "bas",
                ConcertName = "great"


            };
            artEventClassicMusicBL = new ClassicMusicBL
            {
                Id = 15,
                AmountOfTickets = 15,
                Date = new System.DateTime(0),
                EventName = "15",
                Latitude = 50m,
                Longitude = 50m,
                Place = "15",
                Voice = "bas",
                ConcertName = "great"
            };



            _mapper = new Mapper(new MapperConfiguration(conf => conf.AddProfile<BysinessLayerAutoMapperProfile>()));

            mapperArtEventToArtEventBL = new AutoMapperArtEventToBusinesLayer(_mapper);




            orderAndArtEvent = new OrderAndArtEvent { NumberOfBookedTicket = 5, ArtEventId = artEventOpenAir.Id };            
            order = new Order
            {
                Id = 1,
                UserEmail = "test@test.com",
                TimeOfCreation = new System.DateTime(0),
                OrderAndArtEvents = new List<OrderAndArtEvent> { orderAndArtEvent }
            };

            orderAndArtEventFromDALtoBL = new OrderAndArtEvent { NumberOfBookedTicket = 5, ArtEvent = artEventOpenAir };
            orderFromDALtoBL = new Order
            {
                Id = 1,
                UserEmail = "test@test.com",
                TimeOfCreation = new System.DateTime(0),
                OrderAndArtEvents = new List<OrderAndArtEvent> { orderAndArtEventFromDALtoBL }
            };

            cartWithQuantityBL = new CartWithQuantityBL { Quantity = 5, ArtEventBL = artEventOpenAirBL };
            var listOfReservedTickets = new List<CartWithQuantityBL>() { cartWithQuantityBL };

            orderBl = new OrderBL
            {
                Id = 1,
                TimeOfCreation = new System.DateTime(0),
                UserEmail = "test@test.com",
                ListOfReservedEventTickets = listOfReservedTickets
            };


        }


        [SetUp]
        public void Setup()
        {


        }

        #region Check_AutoMapperBetweenOrderOrderBL
        [Test]
        public void Check_AutoMapper_OrderAndArtEvent_cartWithQuantityBL()
        {
            Assert.IsTrue(_mapper.Map<CartWithQuantityBL>(orderAndArtEventFromDALtoBL).IsEqual(cartWithQuantityBL));

        }
        [Test]
        public void Check_AutoMapper_Order_to_OrderBL()
        {

            var wrongOrder1 = new Order
            {
                Id = 2,
                UserEmail = "test@test.com",
                TimeOfCreation = new System.DateTime(0),
                OrderAndArtEvents = new List<OrderAndArtEvent> { orderAndArtEvent }
            };
            var wrongOrder2 = new Order
            {
                Id = 1,
                UserEmail = "2test@test.com",
                TimeOfCreation = new System.DateTime(0),
                OrderAndArtEvents = new List<OrderAndArtEvent> { orderAndArtEvent }
            };
            var wrongOrder3 = new Order
            {
                Id = 1,
                UserEmail = "test@test.com",
                TimeOfCreation = new System.DateTime(100),
                OrderAndArtEvents = new List<OrderAndArtEvent> { orderAndArtEvent }
            };

            Assert.IsTrue(_mapper.Map<OrderBL>(orderFromDALtoBL).IsEqual(orderBl));

            Assert.IsFalse(_mapper.Map<OrderBL>(wrongOrder1).IsEqual(orderBl));
            Assert.IsFalse(_mapper.Map<OrderBL>(wrongOrder2).IsEqual(orderBl));
            Assert.IsFalse(_mapper.Map<OrderBL>(wrongOrder3).IsEqual(orderBl));

        }
        [Test]
        public void Check_AutoMapper_OrderBL_to_Order()
        {
            var result = _mapper.Map<Order>(orderBl);

            Assert.IsTrue(result.IsEqual(order));

        }
        [Test]
        public void Check_AutoMapperBetweenDLandBLlayer_OrderToOrderBL()
        {
            var mapper = new AutoMapperBetweenDLandBLlayer<Order, OrderBL>(_mapper);

            Assert.IsTrue(mapper.Map(orderFromDALtoBL).IsEqual(orderBl));
        }

        [Test]
        public void Check_AutoMapperBetweenDLandBLlayer_OrderBLToOrder()
        {
            var mapper = new AutoMapperBetweenDLandBLlayer<OrderBL, Order>(_mapper);

            Assert.IsTrue(mapper.Map(orderBl).IsEqual(order));
        }
        #endregion Check_MapperArtEventToBusinesLayer


    }
}
