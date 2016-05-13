using Bliffoscope.Analysis.Core.Model.Controller;
using Bliffoscope.Analysis.Core.Search;

namespace Bliffoscope.Analysis.Core.Analysis
{
	public interface IAnalysis
	{
		ITargetSearch SearchTargets(TargetSearchModel targetSearchModel = null);
	}
}
