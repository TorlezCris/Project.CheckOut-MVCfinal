using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System.Web.Http;
using System.Configuration;
using Project.CheckOut.UnitOfWork;
using Project.CheckOut.Repositories.Dapper.Sales;

namespace Project.WebApi.App_Start
{
    public class DIConfig
    {
        public static void ConfigureInjector(HttpConfiguration config)
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            container.Register<IUnitOfWork>(() => new CheckOutUnitOfWork(
                ConfigurationManager.ConnectionStrings["OnlineStoreDBConnection"].ToString()));

            /*Registro del Log4Net*/
            //container.RegisterConditional(typeof(ILog), c => typeof(Log4NetAdapter<>).
            //    MakeGenericType(c.Consumer.ImplementationType), Lifestyle.Singleton, c => true);

            container.Verify();
            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }

        //public sealed class Log4NetAdapter<T> : LogImpl
        //{
        //    public Log4NetAdapter() : base(LogManager.GetLogger(typeof(T)).Logger) { }
        //}
    }
}