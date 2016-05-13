using Bliffoscope.Analysis.Core.Configuration;
using Bliffoscope.Analysis.Core.Data;
using Bliffoscope.Analysis.Core.Domain.Configuration;
using Bliffoscope.Analysis.Core.Scan;

namespace Bliffoscope.Analysis.Runtime.Scan
{
	public class SlimetorpedoScan : Scan, IScan<Slimetorpedo>
	{
		public SlimetorpedoScan(IConfiguration<ConfigurationBlock> configuration) 
			: base(configuration)
		{
			SetFileReader(EnvironmentSettings.SlimeTorpedoFilePath, EnvironmentSettings.SlimeTorpedoFileName);
			SetImageOriginal();
			GetImageOriginal();
			SetImageWithNoWhiteSpaceAround();
		}

		private void SetImageOriginal()
		{
			ImageOriginal = new Slimetorpedo
			{
				RowCount = 13, 
				RowImageStart = 1,
				RowImageEnd = 11,
				ColumnCount = 11,
				ColumnImageStart = 1,
				ColumnImageEnd = 9,
				ImageType = "Slime torpedo"
			};
		}
	}
}
