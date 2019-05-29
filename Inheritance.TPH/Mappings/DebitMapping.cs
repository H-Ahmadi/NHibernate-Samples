using Inheritance.TPH.Model;
using NHibernate.Mapping.ByCode.Conformist;

namespace Inheritance.TPH.Mappings
{
    public class DebitMapping : SubclassMapping<Debit>
    {
        public DebitMapping()
        {
            DiscriminatorValue(2);
            Lazy(false);
        }
    }
}