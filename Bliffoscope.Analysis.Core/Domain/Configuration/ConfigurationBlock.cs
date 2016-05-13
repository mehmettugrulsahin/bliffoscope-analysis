namespace Bliffoscope.Analysis.Core.Domain.Configuration
{
	public class ConfigurationBlock
	{
		public BliffoscopeAnalysisSettings BliffoscopeAnalysisSettings { get; set; }
		public EnvironmentSettings EnvironmentSettings { get; set; }

		public ConfigurationBlock()
		{
			BliffoscopeAnalysisSettings = new BliffoscopeAnalysisSettings();
			EnvironmentSettings = new EnvironmentSettings();
		}
	}
}
