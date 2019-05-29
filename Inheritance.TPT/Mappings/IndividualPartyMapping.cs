using Inheritance.TPT.Model;
using NHibernate.Mapping.ByCode.Conformist;

namespace Inheritance.TPT.Mappings
{
    public class IndividualPartyMapping : JoinedSubclassMapping<IndividualParty>
    {
        public IndividualPartyMapping()
        {
            Table("IndividualParties");
            Lazy(false);
            Property(a => a.SocialSecurityNumber, a=>a.Column("SSN"));
            Key(a=>a.Column("Id"));
        }
    }
}