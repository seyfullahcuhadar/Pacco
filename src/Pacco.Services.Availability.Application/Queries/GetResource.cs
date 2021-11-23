using System;
using Convey.CQRS.Queries;
using Pacco.Services.Availability.Application.DTO;

namespace Pacco.Services.Availability.Application.Queries
{
    public class GetResource : IQuery<ResourceDTO>
    {
        public Guid ResourceId { get; set; }
        
    }
}