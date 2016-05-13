using System.Configuration;
using Bliffoscope.Analysis.Core.Configuration;
using Bliffoscope.Analysis.Core.Constant;

namespace Bliffoscope.Analysis.Configure.Environment
{
	public sealed class EnvironmentConfiguration : Configuration, IEnvironmentConfiguration
	{
		public EnvironmentConfiguration()
		{
			Load();
		}

		public string SlimeTorpedoFilePath { get; set; }
		public string SlimeTorpedoFileName { get; set; }
		public string StarshipFilePath { get; set; }
		public string StarshipFileName { get; set; }
		public string TestDataFilePath { get; set; }
		public string TestDataFileName { get; set; }
		public string SlimetorpedoTargetsFilePath { get; set; }
		public string SlimetorpedoTargetsFileName { get; set; }
		public string StarshipTargetsFilePath { get; set; }
		public string StarshipTargetsFileName { get; set; }

		private class Nested
		{
			// Explicit static constructor to tell C# compiler
			// not to mark type as beforefieldinit
			static Nested()
			{
			}

			internal static readonly EnvironmentConfiguration Instance = new EnvironmentConfiguration();
		}

		public static EnvironmentConfiguration Current
		{
			get { return Nested.Instance; }
		}

		protected override void Load()
		{
			var sections = ConfigurationManager.GetSection(EnvironmentConstants.EnvironmentSections) as EnvironmentConfigurationSection;

			if(sections != null)
			{
				EnvironmentConfigurationElementCollection collection = sections.EnvironmentConfigurations;

				foreach(EnvironmentConfigurationElement element in collection)
				{
					SlimeTorpedoFilePath = element.SlimeTorpedoFilePath;
					SlimeTorpedoFileName = element.SlimeTorpedoFileName;
					StarshipFilePath = element.StarshipFilePath;
					StarshipFileName = element.StarshipFileName;
					TestDataFilePath = element.TestDataFilePath;
					TestDataFileName = element.TestDataFileName;
					SlimetorpedoTargetsFilePath = element.SlimetorpedoTargetsFilePath;
					SlimetorpedoTargetsFileName = element.SlimetorpedoTargetsFileName;
					StarshipTargetsFilePath = element.StarshipTargetsFilePath;
					StarshipTargetsFileName = element.StarshipTargetsFileName;
				}
			}
		}
	}
}