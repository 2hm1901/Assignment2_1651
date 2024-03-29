﻿using System;
using System.Runtime.Serialization;

namespace Assignment2_1651
{
    [Serializable]
    internal class DuplicateIdException : Exception
    {
        public DuplicateIdException()
        {
        }

        public DuplicateIdException(string message) : base(message)
        {
        }

        public DuplicateIdException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DuplicateIdException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}