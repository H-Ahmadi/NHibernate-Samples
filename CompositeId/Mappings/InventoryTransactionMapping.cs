using CompositeId.Model;
using NHibernate.Mapping.ByCode.Conformist;

namespace CompositeId.Mappings
{
    public class InventoryTransactionMapping : ClassMapping<InventoryTransaction>
    {
        public InventoryTransactionMapping()
        {
            Table("InventoryTransactions");
            Lazy(false);
            ComponentAsId(a=>a.Id, map =>
            {
                map.Property(a=>a.Id, a=>a.Column("Id"));
                map.Property(a=>a.OperationPeriodId, a=>a.Column("OperationPeriodId"));
            });
            Property(a=>a.Code);
        }
    }

    public class RealEstateMapping : ClassMapping<RealEstate>
    {
        public RealEstateMapping()
        {
            Table("RealEstates");
            Lazy(false);
            ComponentAsId(a => a.Id, map =>
            {
                map.Property(a => a.Id, a => a.Column("Id"));
            });
            Property(a => a.OwnerName);
        }
    }
}
