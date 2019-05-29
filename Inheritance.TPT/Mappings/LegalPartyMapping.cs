using Inheritance.TPT.Model;
using NHibernate.Mapping.ByCode.Conformist;

namespace Inheritance.TPT.Mappings
{
    public class LegalPartyMapping : JoinedSubclassMapping<LegalParty>
    {
        public LegalPartyMapping()
        {
            Table("LegalParties");
            Lazy(false);
            Property(a => a.CeoName);
            Key(a=>a.Column("Id"));
        }
    }
}