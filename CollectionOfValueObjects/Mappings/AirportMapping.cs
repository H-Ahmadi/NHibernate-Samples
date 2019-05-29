using CollectionOfValueObjects.Model;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace CollectionOfValueObjects.Mappings
{
    public class OrderMapping : ClassMapping<Order>
    {
        public OrderMapping()
        {
            Table("Orders");
            Lazy(false);
            Id(a=>a.Id);
            Property(a=>a.CustomerId);
            Property(a=>a.CreateDate);
            IdBag(p => p.Items, map =>
            {
                map.Table("OrderItems");
                map.Key(m => m.Column("OrderId"));
                map.Access(Accessor.Field);
                map.Cascade(Cascade.All);
                map.Id(i =>
                {
                    i.Column("Id");
                    i.Generator(Generators.Identity);
                });
            }, relation => relation.Component(mapper =>
            {
                mapper.Access(Accessor.Field);
                mapper.Property(p => p.ProductId);
                mapper.Property(p => p.Amount);
                mapper.Property(p => p.Fee);
            }));
        }
    }
}
