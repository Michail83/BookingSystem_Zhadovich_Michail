using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.BusinessLogic.Interfaces
{
    public interface IMapper<Tin, Tout>  
    {
        public Tout Map(Tin incoming);
    }
}
