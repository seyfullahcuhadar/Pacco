using System;
using System.Threading.Tasks;
using Convey.CQRS.Commands;
using Pacco.Services.Availability.Application.Exceptions;
using Pacco.Services.Availability.Core.Entities;
using Pacco.Services.Availability.Core.Repositories;

namespace Pacco.Services.Availability.Application.Commands.Handlers
{
    public class AddResourceHandler:ICommandHandler<AddResource>
    {
        private readonly IResourceRepository _resourceRepository;

        public AddResourceHandler(IResourceRepository resourceRepository)
        {
            _resourceRepository = resourceRepository;
        }
        
        
        public async Task HandleAsync(AddResource command)
        {
            var resource = await _resourceRepository.GetAsync(command.ResourceId);
            if (resource is {})
            {
                throw new ResourceAlreadyExistsException(resource.Id);
            }

            resource = Resource.Create(command.ResourceId, command.Tags);
            await _resourceRepository.AddAsync(resource);
        }
    }
}