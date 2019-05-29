using Inheritance.TPT.Model;
using NHibernate.Mapping.ByCode.Conformist;

namespace Inheritance.TPT.Mappings
{
    public class PartyMapping : ClassMapping<Party>
    {
        public PartyMapping()
        {
            Table("Parties");
            Lazy(false);
            Id(a=>a.Id);
            Property(a=>a.Name);
        }
    }
}
