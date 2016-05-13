using System.Configuration;
using Bliffoscope.Analysis.Core.Constant;

namespace Bliffoscope.Analysis.Configure.Environment
{
	public class EnvironmentConfigurationSection : ConfigurationSection
	{
		[ConfigurationProperty(EnvironmentConstants.EnvironmentConfigurationsSection)]
		public EnvironmentConfigurationElementCollection EnvironmentConfigurations
		{
			get
			{
				EnvironmentConfigurationElementCollection collection = base[EnvironmentConstants.EnvironmentConfigurationsSection] as EnvironmentConfigurationElementCollection;

				return collection ?? new EnvironmentConfigurationElementCollection();
			}
		}
	}
}

