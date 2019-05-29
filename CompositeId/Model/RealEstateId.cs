namespace CompositeId.Model
{
    public class RealEstateId
    {
        public long Id { get;private set; }
        public RealEstateId() { }
        public RealEstateId(long id)
        {
            Id = id;
        }

        protected bool Equals(RealEstateId other)
        {
            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((RealEstateId) obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}