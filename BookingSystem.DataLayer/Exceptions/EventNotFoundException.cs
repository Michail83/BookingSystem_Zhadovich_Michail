using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.DataLayer.Exceptions
{

    [Serializable]
    public class EventNotFoundException : Exception
    {
        public EventNotFoundException() { }
        public EventNotFoundException(string message) : base(message) { }
        public EventNotFoundException(string message, Exception inner) : base(message, inner) { }
        protected EventNotFoundException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
