using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using BookingSystem.BusinessLogic.BusinesLogicModels;
using BookingSystem.DataLayer.EntityModels;

namespace BookingSystem.BusinessLogic.BusinesLogicModels
{
    public class ClassicMusicBL : ArtEventBL
    {
        public string Voice { get; set; }
        public string ConcertName { get; set; }
        public ClassicMusicBL() : base()
        { }

        public ClassicMusicBL(ClassicMusic classicMusic) : base(classicMusic)
        {
            this.Voice = classicMusic.Voice;
            this.ConcertName = classicMusic.ConcertName;
        }

        
    }
}
