using System.Data;
using System.Reflection;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Mapping.ByCode;
using NHibernate.Tool.hbm2ddl;

namespace Configuration
{
    public class SessionFactoryBuilder
    {
        private string connectionString;
        private Assembly mappingAssembly;
        private string sessionFactoryName;

        public SessionFactoryBuilder WithMappingsInAssembly(Assembly assembly)
        {
            mappingAssembly = assembly;
            return this;
        }

        public SessionFactoryBuilder UsingConnectionString(string connectionString)
        {
            this.connectionString = connectionString;
            return this;
        }

        public SessionFactoryBuilder SetSessionNameAs(string name)
        {
            sessionFactoryName = name;
            return this;
        }

        public ISessionFactory Build()
        {
            var configuration = new NHibernate.Cfg.Configuration();
            configuration.SessionFactoryName(sessionFactoryName);
            configuration.DataBaseIntegration(db =>
                {
                    db.Dialect<MsSql2012Dialect>();
                    db.KeywordsAutoImport = Hbm2DDLKeyWords.AutoQuote;
                    db.IsolationLevel = IsolationLevel.ReadCommitted;
                    db.ConnectionString = connectionString;
                    db.Timeout = (byte)10;
                });

            configuration.AddAssembly(mappingAssembly);
            var modelMapper = new ModelMapper();
            modelMapper.BeforeMapClass += (mi, t, map) => map.DynamicUpdate(true);
            modelMapper.AddMappings(mappingAssembly.GetExportedTypes());

            var mappingDocument = modelMapper.CompileMappingForAllExplicitlyAddedEntities();
            configuration.AddDeserializedMapping(mappingDocument, sessionFactoryName);
            SchemaMetadataUpdater.QuoteTableAndColumns(configuration, new MsSql2012Dialect());
            return configuration.BuildSessionFactory();
        }
    }
}