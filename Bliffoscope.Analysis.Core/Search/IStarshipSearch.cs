using Bliffoscope.Analysis.Core.Data;
using Bliffoscope.Analysis.Core.Scan;

namespace Bliffoscope.Analysis.Core.Search
{
	public interface IStarshipSearch : ISearch
	{
		IScan<Starship> StarshipScan { get; }
		void SetStarshipScan(IScan<Starship> starshipScan);
	}
}
