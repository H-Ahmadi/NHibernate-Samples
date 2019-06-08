namespace StatePattern.Model
{
    public class DraftState : OrderState
    {
        public override OrderState Confirm()
        {
            return new ConfirmedState();
        }

        public override OrderState Reject()
        {
            return new RejectedState();
        }

        public override bool CanConfirm() => true;
        public override bool CanEdit() => true;
        public override bool CanReject() => true;
    }
}