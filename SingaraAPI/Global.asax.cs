using SingaraAPI.App_Data;
using System.Web.Http;
using Unity;
using Unity.Injection;
using Unity.WebApi;

namespace SingaraAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RegisterDependencies();
        }
        private void RegisterDependencies()
        {
            var container = new UnityContainer();
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["singara"].ConnectionString;
            container.RegisterType<IDataAccess, DataAccess>(new InjectionConstructor(connectionString));

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}
