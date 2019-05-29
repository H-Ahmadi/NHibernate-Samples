namespace CompositeId.Model
{
    public class InventoryTransactionId
    {
        public long Id { get; private set; }
        public long OperationPeriodId { get; private set; }
        public InventoryTransactionId() { }
        public InventoryTransactionId(long id, long operationPeriodId)
        {
            Id = id;
            OperationPeriodId = operationPeriodId;
        }
        protected bool Equals(InventoryTransactionId other)
        {
            return Id == other.Id && OperationPeriodId == other.OperationPeriodId;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((InventoryTransactionId) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Id.GetHashCode() * 397) ^ OperationPeriodId.GetHashCode();
            }
        }
    }
}