using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BookingSystem.BusinessLogic.Services;
using BookingSystem.BusinessLogic.BusinesLogicModels;
using BookingSystem.DataLayer.EntityModels;
using BookingSystem.BusinessLogic.Interfaces;

using BookingSystem.WEB.Models;

namespace UnitTests
{
    internal static class ExtensionMethod
    {

        public static bool IsEqual(this ArtEventBL artEventBL, ArtEventBL anotherArtEventBL)
        {
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
            if (artEventBL.TypeOfArtEvent== anotherArtEvent.TypeOfArtEvent &&
                artEventBL.Id == anotherArtEvent.Id &&
                artEventBL.EventName == anotherArtEvent.EventName &&
                artEventBL.AmountOfTickets == anotherArtEvent.AmountOfTickets &&
                artEventBL.Date == anotherArtEvent.Date &&
                artEventBL.EventName == anotherArtEvent.EventName &&
                artEventBL.Latitude == anotherArtEvent.Latitude &&
                artEventBL.Longitude == anotherArtEvent.Longitude &&
                artEventBL.Place == anotherArtEvent.Place&&
                artEventBL.AdditionalInfo.SequenceEqual(anotherArtEvent.AdditionalInfo)
                 )
            {
                return true;
            }
            return false;
        }

        public static bool IsEqual(this ArtEvent artEventBL, ArtEvent anotherArtEvent)
        {
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

    }
}
