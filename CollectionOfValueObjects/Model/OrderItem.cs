namespace CollectionOfValueObjects.Model
{
    public class OrderItem
    {
        protected OrderItem()
        {
        }

        public OrderItem(long productId, long amount, long fee)
        {
            ProductId = productId;
            Amount = amount;
            Fee = fee;
        }

        public long ProductId { get; private set; }
        public long Amount { get; private set; }
        public long Fee { get; private set; }

        protected bool Equals(OrderItem other)
        {
            return ProductId == other.ProductId && Amount == other.Amount && Fee == other.Fee;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((OrderItem) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = ProductId.GetHashCode();
                hashCode = (hashCode * 397) ^ Amount.GetHashCode();
                hashCode = (hashCode * 397) ^ Fee.GetHashCode();
                return hashCode;
            }
        }
    }
}