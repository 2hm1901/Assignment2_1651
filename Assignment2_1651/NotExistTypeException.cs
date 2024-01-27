using System;
using System.Runtime.Serialization;

namespace Assignment2_1651
{
    [Serializable]
    internal class NotExistTypeException : Exception
    {
        public NotExistTypeException()
        {
        }

        public NotExistTypeException(string message) : base(message)
        {
        }

        public NotExistTypeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotExistTypeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}