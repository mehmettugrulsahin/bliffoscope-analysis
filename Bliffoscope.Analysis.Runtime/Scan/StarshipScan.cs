using Bliffoscope.Analysis.Core.Configuration;
using Bliffoscope.Analysis.Core.Data;
using Bliffoscope.Analysis.Core.Domain.Configuration;
using Bliffoscope.Analysis.Core.Scan;

namespace Bliffoscope.Analysis.Runtime.Scan
{
	public class StarshipScan : Scan, IScan<Starship>
	{
		public StarshipScan(IConfiguration<ConfigurationBlock> configuration) 
			: base(configuration)
		{
			SetFileReader(EnvironmentSettings.StarshipFilePath, EnvironmentSettings.StarshipFileName);
			SetImageOriginal();
			GetImageOriginal();
			SetImageWithNoWhiteSpaceAround();
		}

		private void SetImageOriginal()
		{
			ImageOriginal = new Starship
			{
				RowCount = 11,
				RowImageStart = 1,
				RowImageEnd = 9,
				ColumnCount = 14,
				ColumnImageStart = 1,
				ColumnImageEnd = 12,
				ImageType = "Star ship"
			};
		}
	}
}
