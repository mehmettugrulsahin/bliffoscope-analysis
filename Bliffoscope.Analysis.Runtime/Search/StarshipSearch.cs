using Bliffoscope.Analysis.Core.Configuration;
using Bliffoscope.Analysis.Core.Data;
using Bliffoscope.Analysis.Core.Domain.Configuration;
using Bliffoscope.Analysis.Core.Scan;
using Bliffoscope.Analysis.Core.Search;

namespace Bliffoscope.Analysis.Runtime.Search
{
	public class StarshipSearch : Search, IStarshipSearch
	{
		public IScan<Starship> StarshipScan { get; private set; }

		public StarshipSearch(IConfiguration<ConfigurationBlock> configuration) 
			: base(configuration)
		{
		}
		
		public void SetStarshipScan(IScan<Starship> starshipScan)
		{
			StarshipScan = starshipScan;
		}

		public void SetBliffoscopeDataSearchScope()
		{
			SetBliffoscopeDataSearchScope(StarshipScan);
		}

		public void AcquireTargets()
		{
			AcquireTargets(StarshipScan);
		}

		public void ExtractTargets()
		{
			ExtractTargets(EnvironmentSettings.StarshipTargetsFilePath, EnvironmentSettings.StarshipTargetsFileName);
		}
	}
}
