﻿namespace Talabat.Shared.Exceptions
{
    public class UnauthorizedException : ApplicationException
    {
        public UnauthorizedException(string? message =null)
            : base(message) { } 
        
            
        
    }
}
