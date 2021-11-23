using System;

namespace Pacco.Services.Availability.Application.Exceptions
{
    public class AppException :Exception
    {
        public virtual string Code { get; }

        public AppException(string message):base(message)
        {
            
        }
    }
}