using System;
using Bliffoscope.Analysis.Core.Analysis;
using Bliffoscope.Analysis.Core.Configuration;
using Bliffoscope.Analysis.Core.Data;
using Bliffoscope.Analysis.Core.Domain.Configuration;
using Bliffoscope.Analysis.Core.Model.Controller;
using Bliffoscope.Analysis.Core.Scan;
using Bliffoscope.Analysis.Core.Search;

namespace Bliffoscope.Analysis.Runtime.Analysis
{
	public class Analysis : IAnalysis
	{
		private readonly IConfiguration<ConfigurationBlock> _configuration;
		private readonly IScan<Slimetorpedo> _slimetorpedoScan;
		private readonly IScan<Starship> _starshipScan;
		private readonly IBliffoscopeScan<BliffoscopeData> _bliffoscopeScan;
		private readonly ITargetSearch _targetSearch;

		private readonly TargetSearchModel _targetSearchModel = new TargetSearchModel();

		private ConfigurationBlock ConfigurationBlock { get; set; }

		public Analysis(
			IConfiguration<ConfigurationBlock> configuration,
			IScan<Slimetorpedo> slimetorpedoScan,
			IScan<Starship> starshipScan,
			IBliffoscopeScan<BliffoscopeData> bliffoscopeScan,
			ITargetSearch targetSearch)
		{
			_configuration = configuration;
			_slimetorpedoScan = slimetorpedoScan;
			_starshipScan = starshipScan;
			_bliffoscopeScan = bliffoscopeScan;
			_targetSearch = targetSearch;

			GetConfigurationBlock();
			GetBliffoscopeAnalysisSettings();
		}

		private void GetConfigurationBlock()
		{
			ConfigurationBlock = _configuration.GetConfigurationBlock();
		}

		private void GetBliffoscopeAnalysisSettings()
		{
			BliffoscopeAnalysisSettings bliffoscopeAnalysisSettings = ConfigurationBlock.BliffoscopeAnalysisSettings;

			_targetSearchModel.SlimetorpedoMatchPercentage = bliffoscopeAnalysisSettings.SlimetorpedoMatchPercentage;
			_targetSearchModel.StarshipMatchPercentage = bliffoscopeAnalysisSettings.StarshipMatchPercentage;
		}

		public ITargetSearch SearchTargets(TargetSearchModel targetSearchModel = null)
		{
			SetSearchModel(targetSearchModel);
			SetMatchPercentages();
			SetScans();
			SetSearchScopes();
			FindTargets();

			return _targetSearch;
		}

		private void SetSearchModel(TargetSearchModel targetSearchModel = null)
		{
			if(targetSearchModel != null)
			{
				_targetSearchModel.SlimetorpedoMatchPercentage = targetSearchModel.SlimetorpedoMatchPercentage;
				_targetSearchModel.StarshipMatchPercentage = targetSearchModel.StarshipMatchPercentage;
				_targetSearchModel.BliffoscopeImage = targetSearchModel.BliffoscopeImage;
			}
		}

		private void SetMatchPercentages()
		{
			_targetSearch.SlimetorpedoSearch.SetMatchPercentage(Convert.ToInt32(_targetSearchModel.SlimetorpedoMatchPercentage));
			_targetSearch.StarshipSearch.SetMatchPercentage(Convert.ToInt32(_targetSearchModel.StarshipMatchPercentage));
		}

		private void SetScans()
		{
			if (_targetSearchModel.BliffoscopeImage != null)
			{
				_bliffoscopeScan.SetImage(_targetSearchModel.BliffoscopeImage);
			}

			SetSlimetorpedoScans();
			SetStarshipScans();
		}

		private void SetSlimetorpedoScans()
		{
			_targetSearch.SlimetorpedoSearch.SetSlimetorpedoScan(_slimetorpedoScan);
			_targetSearch.SlimetorpedoSearch.SetBliffoscopeDataScan(_bliffoscopeScan);
		}

		private void SetStarshipScans()
		{
			_targetSearch.StarshipSearch.SetStarshipScan(_starshipScan);
			_targetSearch.StarshipSearch.SetBliffoscopeDataScan(_bliffoscopeScan);
		}

		private void SetSearchScopes()
		{
			_targetSearch.SlimetorpedoSearch.SetBliffoscopeDataSearchScope();
			_targetSearch.StarshipSearch.SetBliffoscopeDataSearchScope();
		}

		private void FindTargets()
		{
			FindSlimetorpedoTargets();
			FindStarshipTargets();
		}

		private void FindSlimetorpedoTargets()
		{
			_targetSearch.SlimetorpedoSearch.AcquireTargets();
			_targetSearch.SlimetorpedoSearch.ExtractTargets();
		}

		private void FindStarshipTargets()
		{
			_targetSearch.StarshipSearch.AcquireTargets();
			_targetSearch.StarshipSearch.ExtractTargets();
		}
	}
}
