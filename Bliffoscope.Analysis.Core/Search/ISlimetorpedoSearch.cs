using Bliffoscope.Analysis.Core.Data;
using Bliffoscope.Analysis.Core.Scan;

namespace Bliffoscope.Analysis.Core.Search
{
	public interface ISlimetorpedoSearch : ISearch
	{
		IScan<Slimetorpedo> SlimetorpedoScan { get; }
		void SetSlimetorpedoScan(IScan<Slimetorpedo> slimetorpedoScan);		
	}
}
