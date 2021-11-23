using System;

namespace Pacco.Services.Availability.Core.Exceptions
{
    public class InvalidIdAggregateIdException:DomainException
    {
        public  InvalidIdAggregateIdException(Guid id) : base($"Invalid aggregate ID: '{id}' .")
        {
            
        }
    }
}