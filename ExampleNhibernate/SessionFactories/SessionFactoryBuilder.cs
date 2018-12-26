using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System.Reflection;

namespace ExampleNhibernate.SessionFactories
{
    public class SessionFactoryBuilder
    {
        public static ISessionFactory BuildSessionFactory(string connectionStringName,bool create=false,bool update = false)
        {


            //return Fluently.Configure().
            //    Database(MsSqlConfiguration.
            //    MsSql2012.
            //    ConnectionString(c => c.FromConnectionStringWithKey("DbConnection"))).
            //    Mappings(m => m.FluentMappings.AddFromAssemblyOf<NHibernate.Cfg.Mappings>()).
            //    CurrentSessionContext("call").ExposeConfiguration(cfg => BuildSchema(cfg, create, update)).
            //    BuildSessionFactory();



            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(c => c.FromConnectionStringWithKey(connectionStringName)))
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                .ExposeConfiguration(cfg => { new SchemaExport(cfg).Create(false, true); })
                .BuildSessionFactory();


            // return Fluently.Configure().
            //     Database(MsSqlConfiguration.
            //     Standard.
            //     ConnectionString(ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString))
            ////.Mappings(m => entityMappingTypes.ForEach(e => { m.FluentMappings.Add(e); }))  
            //.Mappings(m => m.FluentMappings.AddFromAssemblyOf<NHibernate.Cfg.Mappings>()).CurrentSessionContext("call").ExposeConfiguration(cfg => BuildSchema(cfg, create, update)).BuildSessionFactory();
        }



        private static void BuildSchema(NHibernate.Cfg.Configuration config,bool create=false,bool update=false)
        {
            if(create)
            {
                new SchemaExport(config).Create(false, true);
            }
            else
            {
                new SchemaUpdate(config).Execute(false, update);
            }
        }
    }
}
