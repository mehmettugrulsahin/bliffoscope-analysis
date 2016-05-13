using System.Configuration;
using Bliffoscope.Analysis.Core.Constant;

namespace Bliffoscope.Analysis.Configure.BliffoscopeAnalysis
{
	public class BliffoscopeAnalysisConfigurationSection : ConfigurationSection
	{
		[ConfigurationProperty(BliffoscopeAnalysisConstants.BliffoscopeAnalysisConfigurationsSection)]
		public BliffoscopeAnalysisConfigurationElementCollection BliffoscopeAnalysisConfigurations
		{
			get
			{
				BliffoscopeAnalysisConfigurationElementCollection collection = base[BliffoscopeAnalysisConstants.BliffoscopeAnalysisConfigurationsSection] as BliffoscopeAnalysisConfigurationElementCollection;

				return collection ?? new BliffoscopeAnalysisConfigurationElementCollection();
			}
		}
	}
}

