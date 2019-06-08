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
            SessionFactory = new SessionFactoryBuilder()
                .SetSessionNameAs("Test")
                .WithMappingsInAssembly(Assembly.GetCallingAssembly())
                .UsingConnectionString("data source=localhost;Initial Catalog=NHibernateSampleDB;UID=sa;Password=123QWE!@#")
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