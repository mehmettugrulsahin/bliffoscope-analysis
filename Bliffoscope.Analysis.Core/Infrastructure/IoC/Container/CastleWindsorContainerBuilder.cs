using System.Reflection;
using Bliffoscope.Analysis.Core.Infrastructure.IoC.DependencyResolve;
using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Castle.Windsor.Proxy;

namespace Bliffoscope.Analysis.Core.Infrastructure.IoC.Container
{
	public static class CastleWindsorContainerBuilder
	{
		public static WindsorContainer Build(Assembly assembly, IWindsorInstaller windsorInstaller)
		{
			var container = new WindsorContainer(
				new DefaultKernel(
					new InlineDependenciesPropagatingDependencyResolver(),
					new DefaultProxyFactory()),
				new DefaultComponentInstaller());

			container.Install(windsorInstaller);

			return container;
		}
	}
}
