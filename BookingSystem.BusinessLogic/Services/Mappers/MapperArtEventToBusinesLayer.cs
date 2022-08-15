using BookingSystem.BusinessLogic.BusinesLogicModels;
using BookingSystem.BusinessLogic.Interfaces;
using BookingSystem.DataLayer.EntityModels;
using System;

namespace BookingSystem.BusinessLogic.Services
{
    public class MapperArtEventToBusinesLayer : IMapper<ArtEvent, ArtEventBL>
    {
        IMapper<OpenAir, OpenAirBL> _mapperOpenAirToOpenAirBL;
        IMapper<Party, PartyBL> _mapperPartyToPartyBL;
        IMapper<ClassicMusic, ClassicMusicBL> _mapperClassicMusicToClassicMusicBL;
        public MapperArtEventToBusinesLayer(
            IMapper<OpenAir, OpenAirBL> mapperOpenAirToOpenAirBL,
            IMapper<Party, PartyBL> mapperPartyToPartyBL,
            IMapper<ClassicMusic, ClassicMusicBL> mapperClassicMusicToClassicMusicBL
            )
        {
            _mapperOpenAirToOpenAirBL = mapperOpenAirToOpenAirBL;
            _mapperPartyToPartyBL = mapperPartyToPartyBL;
            _mapperClassicMusicToClassicMusicBL = mapperClassicMusicToClassicMusicBL;
        }

        public ArtEventBL Map(ArtEvent incoming)
        {
            return MapArtEventToBusinessLayerArtEvents(incoming);
        }

        internal PartyBL MapIventsToBusinessLayerIvents(Party party)
        {
            return _mapperPartyToPartyBL.Map(party);
        }

        internal OpenAirBL MapIventsToBusinessLayerIvents(OpenAir openAir)
        {
            return _mapperOpenAirToOpenAirBL.Map(openAir);
        }

        internal ClassicMusicBL MapIventsToBusinessLayerIvents(ClassicMusic classicMusic)
        {
            return _mapperClassicMusicToClassicMusicBL.Map(classicMusic);
        }

        internal virtual ArtEventBL MapArtEventToBusinessLayerArtEvents(ArtEvent ivent) => ivent switch
        {
            Party party => MapIventsToBusinessLayerIvents(party),
            OpenAir openAir => MapIventsToBusinessLayerIvents(openAir),
            ClassicMusic classicMusic => MapIventsToBusinessLayerIvents(classicMusic),
            _ => throw new Exception("Type Not found"),
        };

    }
}
