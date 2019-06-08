using NHibernate.Mapping.ByCode.Conformist;
using StatePattern.Model;

namespace StatePattern.Mappings
{
    public class OrderMapping : ClassMapping<Order>
    {
        public OrderMapping()
        {
            Table("Orders");
            Lazy(false);
            Id(a=>a.Code);
            Property(a=>a.State, a=>a.Type<OrderStateType>());
        }
    }
}