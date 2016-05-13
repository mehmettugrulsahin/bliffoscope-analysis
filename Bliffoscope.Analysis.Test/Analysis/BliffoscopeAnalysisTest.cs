using Bliffoscope.Analysis.Core.Analysis;
using Bliffoscope.Analysis.Core.Search;

namespace Bliffoscope.Analysis.Test.Analysis
{
	public class BliffoscopeAnalysisTest
	{
		private readonly IAnalysis _analysis;

		private ITargetSearch _targetSearch;

		public BliffoscopeAnalysisTest(
			IAnalysis analysis)
		{
			_analysis = analysis;
		}

		public void Analyze()
		{
			SearchTargets();
		}

		private void SearchTargets()
		{
			_targetSearch = _analysis.SearchTargets();
		}
	}
}
