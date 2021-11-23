using System;
using Pacco.Services.Availability.Core.Exceptions;

namespace Pacco.Services.Availability.Core.Entities
{
    public class AggregateId:IEquatable<AggregateId>
    {
        public Guid Value;

        public AggregateId():this(Guid.NewGuid())
        {
                
        }

        public AggregateId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new InvalidIdAggregateIdException(value);
            }

            Value = value;
        }

        public bool Equals(AggregateId other)
        {
            if (ReferenceEquals(null, other)) return false;
            return ReferenceEquals(this, other) || Value.Equals(other.Value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((AggregateId) obj);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public static implicit operator Guid(AggregateId id) => id.Value;

        public static implicit operator AggregateId(Guid id) => new AggregateId();

        public override string ToString() => Value.ToString();
    }
}