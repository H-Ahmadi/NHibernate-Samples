namespace StatePattern.Model
{
    public abstract class OrderState
    {
        public virtual bool CanConfirm() => false;
        public virtual bool CanReject() => false;
        public virtual bool CanEdit() => false;
        public virtual bool CanShip() => false;
        public virtual OrderState Confirm()
        {
            throw new InvalidStateException();
        }
        public virtual OrderState Reject()
        {
            throw new InvalidStateException();
        }

        public virtual OrderState Ship()
        {
            throw new InvalidStateException();
        }
    }
}