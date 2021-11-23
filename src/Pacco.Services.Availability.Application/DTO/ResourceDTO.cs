using System;
using System.Collections;
using System.Collections.Generic;

namespace Pacco.Services.Availability.Application.DTO
{
    public class ResourceDTO
    {
        public Guid Id { get; set; }
        public IEnumerable<string> Tags { get; set; }
        public IEnumerable<ReservationDTO> Reservations { get; set; }
        
    }
}