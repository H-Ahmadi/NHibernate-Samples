using System;
using System.Reflection;
using System.Transactions;
using NHibernate;

namespace Configuration
{
    public abstract class PersistenceTest : IDisposable
    {
        private readonly TransactionScope _scope;

        protected PersistenceTest()
        {
            var x = Assembly.GetCallingAssembly();
            SessionFactory = new SessionFactoryBuilder()
                .SetSessionNameAs("Test")
                .WithMappingsInAssembly(Assembly.GetCallingAssembly())
                .UsingConnectionString("data source=.;Initial Catalog=NHibernateSampleDB;Integrated Security=true")
                .Build();

            _scope = new TransactionScope();
        }

        public ISessionFactory SessionFactory { get; }

        public void Dispose()
        {
            _scope.Dispose();
        }
    }
}