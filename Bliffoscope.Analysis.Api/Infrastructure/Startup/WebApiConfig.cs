using System.Web.Http;
using System.Web.Http.Dispatcher;
using Bliffoscope.Analysis.Core.Infrastructure.IoC.AssemblyResolve;

namespace Bliffoscope.Analysis.Api.Infrastructure.Startup
{
	public static class WebApiConfig
	{
		public static void Configure(IHttpControllerActivator controllerActivator)
		{
			GlobalConfiguration.Configure((c) => ConfigureCore(c, controllerActivator));
		}

		private static void ConfigureCore(HttpConfiguration configuration, IHttpControllerActivator controllerActivator)
		{
			configuration.Services.Replace(typeof(IAssembliesResolver), new AssemblyResolver());

			configuration.Routes.Clear();
			configuration.MapHttpAttributeRoutes();
			configuration.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);

			configuration.Filters.Add(new AuthorizeAttribute());

			configuration.Services.Replace(typeof(IHttpControllerActivator), controllerActivator);

			configuration.SuppressDefaultHostAuthentication();

			configuration.Formatters.JsonFormatter.SerializerSettings.TypeNameHandling = Newtonsoft.Json.TypeNameHandling.None;
			configuration.Formatters.JsonFormatter.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc;
			configuration.Formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.None;
			configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
			configuration.Formatters.Remove(configuration.Formatters.XmlFormatter);

			configuration.EnsureInitialized();
		}
	}
}