using System;

namespace Infra.Exceptions
{
    public class DistanceInvalidException : ArgumentException
    {
        public DistanceInvalidException() : base() { }
        public DistanceInvalidException(string message) : base(message) { }
        public DistanceInvalidException(string message, Exception innerException) 
            : base(message, innerException) { }
        
    }
}