using System;
using System.Linq;
using Pacco.Services.Availability.Core.Entities;
using Pacco.Services.Availability.Core.ValueObjects;

namespace Pacco.Services.Availability.Infrastructure.Mongo.Documents
{
    internal static class Extensions
    {
        public static Resource AsEntity(this ResourceDocument document) => new Resource(document.Id, document.Tags,
            document.Reservations.Select(
                r => new Reservation(r.TimeStamp.AsDateTime(),r.Priority)
            ));

        public static ResourceDocument AsDocument(this Resource entity)
        {
            return new ResourceDocument
            {
                Id = entity.Id,
                Reservations = entity.Reservations.Select(r => new ReservationDocument
                {
                    TimeStamp = r.DateTime.AsDaysSinceEpoach(),
                    Priority = r.Priority
                }),
                Tags = entity.Tags

            };
        }
        public static int  AsDaysSinceEpoach(this DateTime dateTime)
        {
            return (dateTime - new DateTime()).Days;
        }

        public static DateTime AsDateTime(this int timestamp) => new DateTime().AddDays(timestamp);
        
    }
}