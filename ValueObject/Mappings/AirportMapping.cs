using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using ValueObject.Model;

namespace ValueObject.Mappings
{
    public class AirportMapping : ClassMapping<Airport>
    {
        public AirportMapping()
        {
            Table("Airports");
            Lazy(false);
            Id(a=>a.Id);
            Property(a=>a.Name);
            Component(a=>a.Coordinate, map =>
            {
                map.Property(z=>z.Latitude, a=>a.Column("Latitude"));
                map.Property(z=>z.Longitude, a=>a.Column("Longitude"));
            });
        }
    }
}
