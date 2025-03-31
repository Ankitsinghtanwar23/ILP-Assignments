using System;
using System.Runtime.Serialization;

namespace Assignment3
{
    [Serializable]
    internal class ImplementedException : Exception
    {
        public ImplementedException()
        {
        }

        public ImplementedException(string message) : base(message)
        {
        }

        public ImplementedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ImplementedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}