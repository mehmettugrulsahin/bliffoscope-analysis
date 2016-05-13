namespace Bliffoscope.Analysis.Core.Search
{
	public interface ITargetSearch
	{
		ISlimetorpedoSearch SlimetorpedoSearch { get; }
		IStarshipSearch StarshipSearch { get; }
		string ProgressMessage { get; set; }
		string ProgressTime { get; set; }
	}
}
