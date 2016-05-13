using System.Collections.Generic;
using Bliffoscope.Analysis.Core.Data;
using Bliffoscope.Analysis.Core.Model;
using Bliffoscope.Analysis.Core.Scan;

namespace Bliffoscope.Analysis.Core.Search
{
	public interface ISearch
	{
		string TargetsFoundTextImage { get; set; }
		IList<Target> TargetsFound { get; set; }

		IScan<BliffoscopeData> BliffoscopeDataScan { get; }
		void SetBliffoscopeDataScan(IScan<BliffoscopeData> bliffoscopeData);

		int MatchPercentage { get; }
		void SetMatchPercentage(int matchPercentage);

		void SetBliffoscopeDataSearchScope();
		void AcquireTargets();
		void ExtractTargets();
	}
}
