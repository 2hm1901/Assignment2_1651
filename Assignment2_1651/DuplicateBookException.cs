using System;
using System.Runtime.Serialization;

namespace Assignment2_1651
{
    [Serializable]
    internal class DuplicateBookException : Exception
    {
        public DuplicateBookException()
        {
        }

        public DuplicateBookException(string message) : base(message)
        {
        }

        public DuplicateBookException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DuplicateBookException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}