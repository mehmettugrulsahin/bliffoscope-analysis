namespace Bliffoscope.Analysis.Core.Configuration
{
	public interface IEnvironmentConfiguration
	{
		string SlimeTorpedoFilePath { get; set; }
		string SlimeTorpedoFileName { get; set; }
		string StarshipFilePath { get; set; }
		string StarshipFileName { get; set; }
		string TestDataFilePath { get; set; }
		string TestDataFileName { get; set; }
		string SlimetorpedoTargetsFilePath { get; set; }
		string SlimetorpedoTargetsFileName { get; set; }
		string StarshipTargetsFilePath { get; set; }
		string StarshipTargetsFileName { get; set; }

	}
}
