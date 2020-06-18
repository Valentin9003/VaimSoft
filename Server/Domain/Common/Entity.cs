using System;

namespace Domain.Common
{
    public abstract class Entity<TId>
        where TId : struct
    {
        public TId Id { get; private set; } = default;

        protected DateTime DateTimeNow() => DateTime.Now;

        public override bool Equals(object obj)
        {
            if (!(obj is Entity<TId> other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (this.GetType() != other.GetType())
            {
                return false;
            }

            if (this.Equals(default) || other.Equals(default))
            {
                return false;
            }

            return this.Id.Equals(other.Id);
        }

        public static bool operator ==(Entity<TId> first, Entity<TId> second)
        {
            if (first == null && second == null)
            {
                return true;
            }

            if (first == null || second == null)
            {
                return false;
            }

            return first.Equals(second);
        }

        public static bool operator !=(Entity<TId> first, Entity<TId> second) => !(first == second);

        public override int GetHashCode() => (this.GetType().ToString() + this.Id.ToString()).GetHashCode();
    }
}
