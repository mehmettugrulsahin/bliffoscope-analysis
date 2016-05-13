using Bliffoscope.Analysis.Api;
using Bliffoscope.Analysis.Api.Infrastructure.IoC;
using Bliffoscope.Analysis.Api.Infrastructure.Startup;
using Bliffoscope.Analysis.Core.Infrastructure.IoC.AssemblyResolve;
using Bliffoscope.Analysis.Core.Infrastructure.IoC.CompositionRoots;
using Bliffoscope.Analysis.Core.Infrastructure.IoC.Container;
using Castle.MicroKernel.Lifestyle;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace Bliffoscope.Analysis.Api
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

			var thisAssembly = typeof(Startup).Assembly;

			AssemblyScanner.Scan(thisAssembly);

			var container = CastleWindsorContainerBuilder.Build(thisAssembly, new ApiContainerInstaller());
			container.BeginScope();

			OwinConfig.Configure(app);

			WebApiConfig.Configure(new WebApiControllerActivator(container));
		}
	}
}
