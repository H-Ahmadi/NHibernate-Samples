using System;
using System.Collections.Generic;
using System.Text;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using OptimisticConcurrency.Model;

namespace OptimisticConcurrency.Mappings
{
    public class PersonMapping : ClassMapping<Person>
    {
        public PersonMapping()
        {
            Table("People");
            Lazy(false);
            Id(a=>a.Id);
            Property(a=>a.Firstname);
            Property(a=>a.Lastname);
            Version(a=>a.RowVersion, m =>
            {
                m.Column("RowVersion");
                m.Generated(VersionGeneration.Always);
                m.Type<BinaryTimestamp>();
            });
        }
    }
}
