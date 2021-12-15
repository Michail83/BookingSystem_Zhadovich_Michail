using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingSystem.BusinessLogic.Interfaces;
using BookingSystem.BusinessLogic.BusinesLogicModels;
using BookingSystem.DataLayer.EntityModels;

namespace BookingSystem.BusinessLogic.Services
{
    internal class MapperArtEventToBusinesLayer : IMapper<ArtEvent, ArtEventBL>
    {

        public ArtEventBL Map(ArtEvent incoming)
        {
            return MapArtEventToBusinessLayerArtEvents(incoming);
        } 

        internal PartyBL MapIventsToBusinessLayerIvents(Party party)
        {            
            return new PartyBL(party);
        }

        internal OpenAirBL MapIventsToBusinessLayerIvents(OpenAir openAir)
        {            
            return new OpenAirBL(openAir);
        }

        internal ClassicMusicBL MapIventsToBusinessLayerIvents(ClassicMusic classicMusic)
        {            
            return new ClassicMusicBL(classicMusic);
        }

        internal virtual ArtEventBL MapArtEventToBusinessLayerArtEvents(ArtEvent ivent) => ivent.GetType().ToString() switch
        {
            "BookingSystem.DataLayer.EntityModels.Party" => MapIventsToBusinessLayerIvents((Party)ivent),
            "BookingSystem.DataLayer.EntityModels.OpenAir" => MapIventsToBusinessLayerIvents((OpenAir)ivent),
            "BookingSystem.DataLayer.EntityModels.ClassicMusic" => MapIventsToBusinessLayerIvents((ClassicMusic)ivent),
            _ => throw new Exception("Type Not found"),
        };
        
    }
}
