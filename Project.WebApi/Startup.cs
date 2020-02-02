using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;
using Project.WebApi.App_Start;
using System.Web.Http;


[assembly: OwinStartup(typeof(Project.WebApi.Startup))]

namespace Project.WebApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //log4net.Config.XmlConfigurator.Configure();
            //var log = log4net.LogManager.GetLogger(typeof(Startup));
            //log.Debug("Loggin habilitado");

            var config = new HttpConfiguration();
            //config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler());

            DIConfig.ConfigureInjector(config);
            app.UseCors(CorsOptions.AllowAll);
            TokenConfig.ConfigureOAuth(app, config);
            WebApiConfig.Register(config);
            //WebApiConfig.Configure(config);
            app.UseWebApi(config);
        }
    }
}