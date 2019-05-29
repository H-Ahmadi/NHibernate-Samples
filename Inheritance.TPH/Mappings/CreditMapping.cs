using Inheritance.TPH.Model;
using NHibernate.Mapping.ByCode.Conformist;

namespace Inheritance.TPH.Mappings
{
    public class CreditMapping : SubclassMapping<Credit>
    {
        public CreditMapping()
        {
            DiscriminatorValue(1);
            Lazy(false);
        }
    }
}