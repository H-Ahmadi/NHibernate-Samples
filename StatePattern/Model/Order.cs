namespace StatePattern.Model
{
    public class Order
    {
        public long Code { get; private set; }
        public OrderState State { get; private set; }

        private Order() { }
        public Order(long code)
        {
            this.Code = code;
            this.State = new DraftState();
        }
        
        public void Confirm()
        {
            this.State = this.State.Confirm();
        }

        public void Ship()
        {
            this.State = this.State.Ship();
        }

        public void Reject()
        {
            this.State = this.State.Reject();
        }
    }
}