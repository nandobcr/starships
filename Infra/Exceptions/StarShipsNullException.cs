using System;

namespace Infra.Exceptions
{
    public class StarShipsNullException : StarShipFacadeException
    {
        public StarShipsNullException() : base() { }
        public StarShipsNullException(string message) : base(message) { }
        public StarShipsNullException(string message, Exception innerException) 
            : base(message, innerException) { }
        
    }
}