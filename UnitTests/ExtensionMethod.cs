using BookingSystem.BusinessLogic.BusinesLogicModels;
using BookingSystem.DataLayer.EntityModels;
using BookingSystem.WEB.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace UnitTests
{
    internal static class ExtensionMethod
    {

        public static bool IsEqual(this ArtEventBL artEventBL, ArtEventBL anotherArtEventBL)
        {
            if (artEventBL == null && anotherArtEventBL == null)
            {
                return true;
            }
            if (artEventBL == null || anotherArtEventBL == null)
            {
                return false;
            }

            if (artEventBL.GetType().ToString().Equals(anotherArtEventBL.GetType().ToString()) &&
                artEventBL.Id == anotherArtEventBL.Id &&
                artEventBL.EventName == anotherArtEventBL.EventName &&
                artEventBL.AmountOfTickets == anotherArtEventBL.AmountOfTickets &&
                artEventBL.Date == anotherArtEventBL.Date &&
                artEventBL.EventName == anotherArtEventBL.EventName &&
                artEventBL.Latitude == anotherArtEventBL.Latitude &&
                artEventBL.Longitude == anotherArtEventBL.Longitude &&
                artEventBL.Place == anotherArtEventBL.Place
                 )
            {
                switch (artEventBL)
                {
                    case OpenAirBL openAir when openAir.HeadLiner == ((OpenAirBL)anotherArtEventBL).HeadLiner:
                        return true;
                    case ClassicMusicBL classicMusic when classicMusic.ConcertName ==
                    ((ClassicMusicBL)anotherArtEventBL).ConcertName &&
                    classicMusic.Voice == ((ClassicMusicBL)anotherArtEventBL).Voice:
                        return true;
                    case PartyBL partyBL when partyBL.AgeLimitation == ((PartyBL)anotherArtEventBL).AgeLimitation:
                        return true;
                    default:
                        break;
                }
            }
            return false;
        }
        public static bool IsEqual(this ArtEventViewModel artEventBL, ArtEventViewModel anotherArtEvent)
        {
            if (artEventBL == null && anotherArtEvent == null)
            {
                return true;
            }
            if (artEventBL == null || anotherArtEvent == null)
            {
                return false;
            }
            if (artEventBL.TypeOfArtEvent == anotherArtEvent.TypeOfArtEvent &&
                artEventBL.Id == anotherArtEvent.Id &&
                artEventBL.EventName == anotherArtEvent.EventName &&
                artEventBL.AmountOfTickets == anotherArtEvent.AmountOfTickets &&
                artEventBL.Date == anotherArtEvent.Date &&
                artEventBL.EventName == anotherArtEvent.EventName &&
                artEventBL.Latitude == anotherArtEvent.Latitude &&
                artEventBL.Longitude == anotherArtEvent.Longitude &&
                artEventBL.Place == anotherArtEvent.Place &&
                artEventBL.AdditionalInfo.SequenceEqual(anotherArtEvent.AdditionalInfo)
                 )
            {
                return true;
            }
            return false;
        }

        public static bool IsEqual(this ArtEvent artEventBL, ArtEvent anotherArtEvent)
        {
            if (artEventBL == null && anotherArtEvent == null)
            {
                return true;
            }
            if (artEventBL == null || anotherArtEvent == null)
            {
                return false;
            }


            if (artEventBL.GetType().ToString().Equals(anotherArtEvent.GetType().ToString()) &&
                artEventBL.Id == anotherArtEvent.Id &&
                artEventBL.EventName == anotherArtEvent.EventName &&
                artEventBL.AmountOfTickets == anotherArtEvent.AmountOfTickets &&
                artEventBL.Date == anotherArtEvent.Date &&
                artEventBL.EventName == anotherArtEvent.EventName &&
                artEventBL.Latitude == anotherArtEvent.Latitude &&
                artEventBL.Longitude == anotherArtEvent.Longitude &&
                artEventBL.Place == anotherArtEvent.Place
                 )
            {
                switch (artEventBL)
                {
                    case OpenAir openAir when openAir.HeadLiner == ((OpenAir)anotherArtEvent).HeadLiner:
                        return true;
                    case ClassicMusic classicMusic when classicMusic.ConcertName ==
                    ((ClassicMusic)anotherArtEvent).ConcertName &&
                    classicMusic.Voice == ((ClassicMusic)anotherArtEvent).Voice:
                        return true;
                    case Party partyBL when partyBL.AgeLimitation == ((Party)anotherArtEvent).AgeLimitation:
                        return true;
                    default:
                        break;
                }
            }
            return false;
        }

        public static bool IsEqual(this CartWithQuantityBL cartWithQuantityBL, CartWithQuantityBL anotherCartWithQuantityBL)
        {
            if (cartWithQuantityBL.Quantity == anotherCartWithQuantityBL.Quantity &&
                cartWithQuantityBL.ArtEventBL.IsEqual(anotherCartWithQuantityBL.ArtEventBL)
                )
            {
                return true;
            }
            return false;
        }
        public static bool IsEqual(this OrderBL orderBl, OrderBL anotherOrderBL)
        {
            if (orderBl == null && anotherOrderBL == null)
            {
                return true;
            }
            if (orderBl == null || anotherOrderBL == null)
            {
                return false;
            }
            if (
                orderBl.Id == anotherOrderBL.Id
                && orderBl.ListOfReservedEventTickets.SequenceEqual(anotherOrderBL.ListOfReservedEventTickets, new CartWithQuantityComparer())
                && orderBl.TimeOfCreation == anotherOrderBL.TimeOfCreation
                && orderBl.UserEmail == anotherOrderBL.UserEmail
                )
            {
                return true;
            }
            return false;
        }
        public static bool IsEqual(this OrderViewModel orderViewModel, OrderViewModel anotherOrderViewModel)
        {
            if (orderViewModel == null && anotherOrderViewModel == null)
            {
                return true;
            }
            if (orderViewModel == null || anotherOrderViewModel == null)
            {
                return false;
            }
            if (
                orderViewModel.Id == anotherOrderViewModel.Id
                && orderViewModel.ListOfReservedEventTickets.SequenceEqual(anotherOrderViewModel.ListOfReservedEventTickets, new OrderViewModelComparer())
                && orderViewModel.TimeOfCreation == anotherOrderViewModel.TimeOfCreation
                && orderViewModel.UserEmail == anotherOrderViewModel.UserEmail
                )
            {
                return true;
            }
            return false;
        }
        public static bool IsEqual(this Order order, Order anotherOrder)
        {
            if (order == null && anotherOrder == null)
            {
                return true;
            }
            if (order == null || anotherOrder == null)
            {
                return false;
            }
            if (
                order.Id == anotherOrder.Id
                && order.TimeOfCreation == anotherOrder.TimeOfCreation
                && order.UserEmail == anotherOrder.UserEmail
                && order.OrderAndArtEvents.SequenceEqual(anotherOrder.OrderAndArtEvents, new OrderAndArtEventComparer())
                )
            {
                return true;
            }
            return false;
        }
        public static bool IsEqual(this OrderAndArtEvent orderAndArtEvent, OrderAndArtEvent anotherOrderAndArtEvent)
        {
            if (orderAndArtEvent == null && anotherOrderAndArtEvent == null)
            {
                return true;
            }
            if (orderAndArtEvent == null || anotherOrderAndArtEvent == null)
            {
                return false;
            }
            if (
                orderAndArtEvent.NumberOfBookedTicket == anotherOrderAndArtEvent.NumberOfBookedTicket
                && orderAndArtEvent.ArtEvent.IsEqual(anotherOrderAndArtEvent.ArtEvent)
                && orderAndArtEvent.OrderId == anotherOrderAndArtEvent.OrderId
                )
            {
                return true;
            }
            return false;
        }
        public static bool IsEqual(this CartWithQuantityViewModel cartWithQuantityViewModel,
            CartWithQuantityViewModel anothercartWithQuantityViewModel)
        {
            if (cartWithQuantityViewModel.Quantity == anothercartWithQuantityViewModel.Quantity &&
                cartWithQuantityViewModel.ArtEventViewModel.IsEqual(anothercartWithQuantityViewModel.ArtEventViewModel)
                )
            {
                return true;
            }
            return false;
        }
    }
    public class CartWithQuantityComparer : IEqualityComparer<CartWithQuantityBL>
    {
        public bool Equals(CartWithQuantityBL x, CartWithQuantityBL y)
        {
            return x.IsEqual(y);
        }
        public int GetHashCode([DisallowNull] CartWithQuantityBL obj)
        {
            return obj.Quantity.GetHashCode();
        }
    }
    public class OrderAndArtEventComparer : IEqualityComparer<OrderAndArtEvent>
    {
        public bool Equals(OrderAndArtEvent x, OrderAndArtEvent y)
        {
            return x.IsEqual(y);
        }
        public int GetHashCode([DisallowNull] OrderAndArtEvent obj)
        {
            return obj.NumberOfBookedTicket.GetHashCode();
        }
    }
    public class OrderViewModelComparer : IEqualityComparer<CartWithQuantityViewModel>
    {
        public bool Equals(CartWithQuantityViewModel x, CartWithQuantityViewModel y)
        {

            return x.IsEqual(y);
        }
        public int GetHashCode([DisallowNull] CartWithQuantityViewModel obj)
        {
            return obj.Quantity.GetHashCode();
        }
    }


}
