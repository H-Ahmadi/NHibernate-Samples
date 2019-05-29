using System.Data;
using FizzWare.NBuilder.Extensions;
using Inheritance.TPH.Model;
using NHibernate;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.SqlTypes;

namespace Inheritance.TPH.Mappings
{
    public class TransactionMapping : ClassMapping<Transaction>
    {
        public TransactionMapping()
        {
            Table("Transactions");
            Lazy(false);
            Id(a=>a.Id);
            Property(a=>a.Code);
            Property(a=>a.Amount);

            Discriminator(a =>
            {
                a.Type(NHibernateUtil.Int64);
                a.Column("Discriminator");
            });
            DiscriminatorValue(0);
        }
    }
}
