using Bliffoscope.Analysis.Core.Search;

namespace Bliffoscope.Analysis.Runtime.Search
{
	public class TargetSearch : ITargetSearch
	{
		public TargetSearch(
			ISlimetorpedoSearch slimeTorpedoSearch,
			IStarshipSearch starShipSearch)
		{
			SlimetorpedoSearch = slimeTorpedoSearch;
			StarshipSearch = starShipSearch;
		}

		public ISlimetorpedoSearch SlimetorpedoSearch { get; }
		public IStarshipSearch StarshipSearch { get; }
		public string ProgressMessage { get; set; }
		public string ProgressTime { get; set; }
	}
}
