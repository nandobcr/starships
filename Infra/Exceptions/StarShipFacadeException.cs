using System;

namespace Infra.Exceptions
{
    public class StarShipFacadeException : Exception
    {
        public StarShipFacadeException() : base() { }
        public StarShipFacadeException(string message) : base(message) { }
        public StarShipFacadeException(string message, Exception innerException) 
            : base(message, innerException) { }
    }
}