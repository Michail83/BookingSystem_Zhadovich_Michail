﻿using System;

namespace BookingSystem.DataLayer.Exceptions
{
    [Serializable]
    public class EFCoreDbException : Exception
    {
        public EFCoreDbException() { }
        public EFCoreDbException(string message) : base(message) { }
        public EFCoreDbException(string message, Exception inner) : base(message, inner) { }
        protected EFCoreDbException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
