using System.Configuration;
using Bliffoscope.Analysis.Core.Constant;

namespace Bliffoscope.Analysis.Configure.BliffoscopeAnalysis
{
	public class BliffoscopeAnalysisConfigurationElement : ConfigurationElement
	{
		[ConfigurationProperty(ConfigurationConstants.KeyProperty, IsRequired = true)]
		public string Key
		{
			get
			{
				string value = base[ConfigurationConstants.KeyProperty] as string;

				return value ?? string.Empty;
			}
		}

        [ConfigurationProperty(BliffoscopeAnalysisConstants.StarshipMatchPercentageProperty, IsRequired = true)]
        public string StarshipMatchPercentage
		{
			get
			{
                string value = base[BliffoscopeAnalysisConstants.StarshipMatchPercentageProperty] as string;

				return value ?? string.Empty;
			}
		}

		[ConfigurationProperty(BliffoscopeAnalysisConstants.SlimetorpedoMatchPercentageProperty, IsRequired = true)]
		public string SlimetorpedoMatchPercentage
		{
			get
			{
				string value = base[BliffoscopeAnalysisConstants.SlimetorpedoMatchPercentageProperty] as string;

				return value ?? string.Empty;
			}
		}
	}
}
