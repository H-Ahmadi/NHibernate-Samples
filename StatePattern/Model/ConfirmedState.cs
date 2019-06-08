namespace StatePattern.Model
{
    public class ConfirmedState : OrderState
    {
        public override bool CanShip() => true;
        public override OrderState Ship()
        {
            return new ShippedState();
        }
    }
}