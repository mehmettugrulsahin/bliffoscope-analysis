using System.Configuration;
using Bliffoscope.Analysis.Core.Constant;

namespace Bliffoscope.Analysis.Configure.Environment
{
	public class EnvironmentConfigurationElement : ConfigurationElement
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

        [ConfigurationProperty(EnvironmentConstants.SlimeTorpedoFilePathProperty, IsRequired = true)]
        public string SlimeTorpedoFilePath
		{
			get
			{
                string value = base[EnvironmentConstants.SlimeTorpedoFilePathProperty] as string;

				return value ?? string.Empty;
			}
		}

		[ConfigurationProperty(EnvironmentConstants.SlimeTorpedoFileNameProperty, IsRequired = true)]
		public string SlimeTorpedoFileName
		{
			get
			{
				string value = base[EnvironmentConstants.SlimeTorpedoFileNameProperty] as string;

				return value ?? string.Empty;
			}
		}

		[ConfigurationProperty(EnvironmentConstants.StarshipFilePathProperty, IsRequired = true)]
		public string StarshipFilePath
		{
			get
			{
				string value = base[EnvironmentConstants.StarshipFilePathProperty] as string;

				return value ?? string.Empty;
			}
		}

		[ConfigurationProperty(EnvironmentConstants.StarshipFileNameProperty, IsRequired = true)]
		public string StarshipFileName
		{
			get
			{
				string value = base[EnvironmentConstants.StarshipFileNameProperty] as string;

				return value ?? string.Empty;
			}
		}

		[ConfigurationProperty(EnvironmentConstants.TestDataFilePathProperty, IsRequired = true)]
		public string TestDataFilePath
		{
			get
			{
				string value = base[EnvironmentConstants.TestDataFilePathProperty] as string;

				return value ?? string.Empty;
			}
		}

		[ConfigurationProperty(EnvironmentConstants.TestDataFileNameProperty, IsRequired = true)]
		public string TestDataFileName
		{
			get
			{
				string value = base[EnvironmentConstants.TestDataFileNameProperty] as string;

				return value ?? string.Empty;
			}
		}

		//

		[ConfigurationProperty(EnvironmentConstants.SlimetorpedoTargetsFilePathProperty, IsRequired = true)]
		public string SlimetorpedoTargetsFilePath
		{
			get
			{
				string value = base[EnvironmentConstants.SlimetorpedoTargetsFilePathProperty] as string;

				return value ?? string.Empty;
			}
		}

		[ConfigurationProperty(EnvironmentConstants.SlimetorpedoTargetsFileNameProperty, IsRequired = true)]
		public string SlimetorpedoTargetsFileName
		{
			get
			{
				string value = base[EnvironmentConstants.SlimetorpedoTargetsFileNameProperty] as string;

				return value ?? string.Empty;
			}
		}

		[ConfigurationProperty(EnvironmentConstants.StarshipTargetsFilePathProperty, IsRequired = true)]
		public string StarshipTargetsFilePath
		{
			get
			{
				string value = base[EnvironmentConstants.StarshipTargetsFilePathProperty] as string;

				return value ?? string.Empty;
			}
		}

		[ConfigurationProperty(EnvironmentConstants.StarshipTargetsFileNameProperty, IsRequired = true)]
		public string StarshipTargetsFileName
		{
			get
			{
				string value = base[EnvironmentConstants.StarshipTargetsFileNameProperty] as string;

				return value ?? string.Empty;
			}
		}
	}
}
