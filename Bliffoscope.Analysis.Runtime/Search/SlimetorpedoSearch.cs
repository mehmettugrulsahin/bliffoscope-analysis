using Bliffoscope.Analysis.Core.Configuration;
using Bliffoscope.Analysis.Core.Data;
using Bliffoscope.Analysis.Core.Domain.Configuration;
using Bliffoscope.Analysis.Core.Scan;
using Bliffoscope.Analysis.Core.Search;

namespace Bliffoscope.Analysis.Runtime.Search
{
	public class SlimetorpedoSearch : Search, ISlimetorpedoSearch
	{
		public IScan<Slimetorpedo> SlimetorpedoScan { get; private set; }

		public SlimetorpedoSearch(IConfiguration<ConfigurationBlock> configuration)
			: base(configuration)
		{
		}

		public void SetSlimetorpedoScan(IScan<Slimetorpedo> slimetorpedoScan)
		{
			SlimetorpedoScan = slimetorpedoScan;
		}

		public void SetBliffoscopeDataSearchScope()
		{
			SetBliffoscopeDataSearchScope(SlimetorpedoScan);
		}

		public void AcquireTargets()
		{
			AcquireTargets(SlimetorpedoScan);
		}

		public void ExtractTargets()
		{
			ExtractTargets(EnvironmentSettings.SlimetorpedoTargetsFilePath, EnvironmentSettings.SlimetorpedoTargetsFileName);
		}
	}
}
