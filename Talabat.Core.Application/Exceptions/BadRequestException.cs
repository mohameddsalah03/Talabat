﻿namespace Talabat.Core.Application.Exceptions
{
    public class BadRequestException : ApplicationException
    {
        public BadRequestException(string? message=null) 
           : base(message)
        {

        }
    }
}
