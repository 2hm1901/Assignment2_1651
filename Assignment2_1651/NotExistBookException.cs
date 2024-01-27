using System;
using System.Runtime.Serialization;

namespace Assignment2_1651
{
    [Serializable]
    internal class NotExistBookException : Exception
    {
        public NotExistBookException()
        {
        }

        public NotExistBookException(string message) : base(message)
        {
        }

        public NotExistBookException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotExistBookException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}