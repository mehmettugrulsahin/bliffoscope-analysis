using System.Configuration;
using Bliffoscope.Analysis.Core.Configuration;
using Bliffoscope.Analysis.Core.Constant;

namespace Bliffoscope.Analysis.Configure.BliffoscopeAnalysis
{
	public sealed class BliffoscopeAnalysisConfiguration : Configuration, IBliffoscopeAnalysisConfiguration
	{
		public BliffoscopeAnalysisConfiguration()
		{
			Load();
		}

		public string StarshipMatchPercentage { get; set; }
		public string SlimetorpedoMatchPercentage { get; set; }

		private class Nested
		{
			// Explicit static constructor to tell C# compiler
			// not to mark type as beforefieldinit
			static Nested()
			{
			}

			internal static readonly BliffoscopeAnalysisConfiguration Instance = new BliffoscopeAnalysisConfiguration();
		}

		public static BliffoscopeAnalysisConfiguration Current
		{
			get { return Nested.Instance; }
		}

		protected override void Load()
		{
			var sections = ConfigurationManager.GetSection(BliffoscopeAnalysisConstants.BliffoscopeAnalysisSections) as BliffoscopeAnalysisConfigurationSection;

			if(sections != null)
			{
				BliffoscopeAnalysisConfigurationElementCollection collection = sections.BliffoscopeAnalysisConfigurations;

				foreach(BliffoscopeAnalysisConfigurationElement element in collection)
				{
					StarshipMatchPercentage = element.StarshipMatchPercentage;
					SlimetorpedoMatchPercentage = element.SlimetorpedoMatchPercentage;
				}
			}
		}
	}
}