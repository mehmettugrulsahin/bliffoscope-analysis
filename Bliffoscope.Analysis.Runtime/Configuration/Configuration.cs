using System;
using System.IO;
using Bliffoscope.Analysis.Core.Configuration;
using Bliffoscope.Analysis.Core.Constant;
using Bliffoscope.Analysis.Core.Domain.Configuration;
using Bliffoscope.Analysis.Core.Extension;

namespace Bliffoscope.Analysis.Runtime.Configuration
{
	public class Configuration : IConfiguration<ConfigurationBlock>
	{
		private readonly IBliffoscopeAnalysisConfiguration _bliffoscopeAnalysisConfiguration;
		private readonly IEnvironmentConfiguration _environmentConfiguration;

		private ConfigurationBlock _configurationBlock;

		public Configuration(
			IBliffoscopeAnalysisConfiguration bliffoscopeAnalysisConfiguration,
			IEnvironmentConfiguration environmentConfiguration
			)
		{
			_bliffoscopeAnalysisConfiguration = bliffoscopeAnalysisConfiguration;
			_environmentConfiguration = environmentConfiguration;
		}

		public ConfigurationBlock GetConfigurationBlock()
		{
			SetConfigurationBlock();
			SetSlimetorpedoFile();
			SetStarshipFile();
			SetTestDataFile();

			return _configurationBlock;
		}

		private void SetConfigurationBlock()
		{
			_configurationBlock = new ConfigurationBlock
			{
				BliffoscopeAnalysisSettings =
				{
					StarshipMatchPercentage = _bliffoscopeAnalysisConfiguration.StarshipMatchPercentage,
					SlimetorpedoMatchPercentage = _bliffoscopeAnalysisConfiguration.SlimetorpedoMatchPercentage
				},

				EnvironmentSettings =
				{
					SlimeTorpedoFilePath = _environmentConfiguration.SlimeTorpedoFilePath,
					SlimeTorpedoFileName = _environmentConfiguration.SlimeTorpedoFileName,
					StarshipFilePath = _environmentConfiguration.StarshipFilePath,
					StarshipFileName = _environmentConfiguration.StarshipFileName,
					TestDataFilePath = _environmentConfiguration.TestDataFilePath,
					TestDataFileName = _environmentConfiguration.TestDataFileName,
					SlimetorpedoTargetsFilePath = _environmentConfiguration.SlimetorpedoTargetsFilePath,
					SlimetorpedoTargetsFileName = _environmentConfiguration.SlimetorpedoTargetsFileName,
					StarshipTargetsFilePath = _environmentConfiguration.StarshipTargetsFilePath,
					StarshipTargetsFileName = _environmentConfiguration.StarshipTargetsFileName
				}
			};
		}

		private void SetSlimetorpedoFile()
		{
			DeployFile(
				TargetSearchConstants.SlimeTorpedoFilePath,
				TargetSearchConstants.SlimeTorpedoFileName,
				_configurationBlock.EnvironmentSettings.SlimeTorpedoFilePath,
				_configurationBlock.EnvironmentSettings.SlimeTorpedoFileName);
		}

		private void SetStarshipFile()
		{
			DeployFile(
				TargetSearchConstants.StarshipFilePath,
				TargetSearchConstants.StarshipFileName,
				_configurationBlock.EnvironmentSettings.StarshipFilePath,
				_configurationBlock.EnvironmentSettings.StarshipFileName);
		}

		private void SetTestDataFile()
		{
			DeployFile(
				TargetSearchConstants.TestDataFilePath,
				TargetSearchConstants.TestDataFileName,
				_configurationBlock.EnvironmentSettings.TestDataFilePath,
				_configurationBlock.EnvironmentSettings.TestDataFileName);
		}

		private void DeployFile(string sourceFilePath, string sourceFileName, string targetFilePath, string targetFileName)
		{
			if(!Directory.Exists(targetFilePath))
			{
				Directory.CreateDirectory(targetFilePath);
			}

			if(!File.Exists($"{targetFilePath.WithEndingSlash()}{targetFileName}"))
			{
				File.Copy(
					$"{Environment.CurrentDirectory.WithEndingSlash()}{sourceFilePath.WithEndingSlash()}{sourceFileName}",
					$"{targetFilePath.WithEndingSlash()}{targetFileName}");
			}
		}
	}
}
