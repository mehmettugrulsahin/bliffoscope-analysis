using System.Net.Http;
using System.Web.Http;
using Bliffoscope.Analysis.Configure.BliffoscopeAnalysis;
using Bliffoscope.Analysis.Configure.Environment;
using Bliffoscope.Analysis.Core.Analysis;
using Bliffoscope.Analysis.Core.Configuration;
using Bliffoscope.Analysis.Core.Data;
using Bliffoscope.Analysis.Core.Domain.Configuration;
using Bliffoscope.Analysis.Core.Scan;
using Bliffoscope.Analysis.Core.Search;
using Bliffoscope.Analysis.Runtime.Configuration;
using Bliffoscope.Analysis.Runtime.Scan;
using Bliffoscope.Analysis.Runtime.Search;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bliffoscope.Analysis.Api.Infrastructure.IoC
{
	public class ApiContainerInstaller : IWindsorInstaller
	{
		private IWindsorContainer _container;

		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			_container = container;

			RegisterWebApiComponents();
			RegisterConfigurationComponents();
			RegisterTargetSearchComponents();
			RegisterAnalysisComponents();
		}

		private void RegisterWebApiComponents()
		{
			_container.Register(
				// Register all Web Api controllers
				Types
					.FromAssembly(this.GetType().Assembly)
					.BasedOn<ApiController>()
					.WithService.Self()
					.LifestyleScoped(),

				// Register the httprequestmessage as named item
				Component.For<HttpRequestMessage>()
					.LifestyleScoped()
			);
		}

		private void RegisterConfigurationComponents()
		{
			_container.Register(
				Component.For(typeof(IConfiguration<ConfigurationBlock>)).ImplementedBy<Configuration>().LifestyleScoped(),
				Component.For<IEnvironmentConfiguration>().ImplementedBy<EnvironmentConfiguration>().LifestyleSingleton(),
				Component.For<IBliffoscopeAnalysisConfiguration>().ImplementedBy<BliffoscopeAnalysisConfiguration>().LifestyleSingleton()
			);
		}

		private void RegisterTargetSearchComponents()
		{
			_container.Register(
				Component.For<ITargetSearch>().ImplementedBy<TargetSearch>().LifestyleTransient(),
				Component.For<ISlimetorpedoSearch>().ImplementedBy<SlimetorpedoSearch>().LifestyleTransient(),
				Component.For<IStarshipSearch>().ImplementedBy<StarshipSearch>().LifestyleTransient()
			);
		}

		private void RegisterAnalysisComponents()
		{
			_container.Register(
				Component.For<IAnalysis>().ImplementedBy<Runtime.Analysis.Analysis>().LifestyleTransient(),
				Component.For(typeof(IScan<Slimetorpedo>)).ImplementedBy<SlimetorpedoScan>().LifestyleTransient(),
				Component.For(typeof(IScan<Starship>)).ImplementedBy<StarshipScan>().LifestyleTransient(),
				Component.For(typeof(IBliffoscopeScan<BliffoscopeData>)).ImplementedBy<BliffoscopeDataScan>().LifestyleTransient()
			);
		}
	}
}