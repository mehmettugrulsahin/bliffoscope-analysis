using System.Collections.Generic;
using System.Linq;
using Bliffoscope.Analysis.Core.Configuration;
using Bliffoscope.Analysis.Core.Data;
using Bliffoscope.Analysis.Core.Domain.Configuration;
using Bliffoscope.Analysis.Core.Scan;

namespace Bliffoscope.Analysis.Runtime.Scan
{
	public class BliffoscopeDataScan : Scan, IBliffoscopeScan<BliffoscopeData>
	{
		public BliffoscopeDataScan(IConfiguration<ConfigurationBlock> configuration) 
			: base(configuration)
		{
			SetFileReader(EnvironmentSettings.TestDataFilePath, EnvironmentSettings.TestDataFileName);
			SetImageOriginal();
			GetImageOriginal();
			SetImageWithNoWhiteSpaceAround();
		}

		private void SetImageOriginal()
		{
			ImageOriginal = new BliffoscopeData
			{
				RowCount = 100,
				RowImageStart = 0,
				RowImageEnd = 99,
				ColumnCount = 100,
				ColumnImageStart = 0,
				ColumnImageEnd = 99
			};
		}

		public void SetImage(string bliffoscopeData)
		{
			SetImageOriginal(bliffoscopeData);
			GetImageOriginal(bliffoscopeData);
			SetImageWithNoWhiteSpaceAround();
		}

		private void SetImageOriginal(string bliffoscopeData)
		{
			IList<string> imageLines = bliffoscopeData.Split('\n');
			int maximumLineLength = imageLines.OrderByDescending(s => s.Length).First().Length;

			ImageOriginal = new BliffoscopeData
			{
				RowCount = imageLines.Count,
				RowImageStart = 0,
				RowImageEnd = imageLines.Count - 1,
				ColumnCount = maximumLineLength,
				ColumnImageStart = 0,
				ColumnImageEnd = maximumLineLength - 1
			};
		}

		public void GetImageOriginal(string bliffoscopeData)
		{
			IList<string> imageLines = bliffoscopeData.Split('\n');

			int lineIndex;
			for(lineIndex = 0; lineIndex < imageLines.Count; lineIndex++)
			{
				string line = imageLines[lineIndex];
				int characterIndex = 0;
				if(line != null)
				{
					foreach(char character in line)
					{
						ImageOriginal.Pixels.Add(
							new Pixel
							{
								Row = lineIndex,
								Column = characterIndex++,
								OriginalValue = character,
								MarkedTemporary = false,
								MarkedTemporaryValue = character,
								MarkedPermanent = false,
								MarkedPermanentValue = character,
								SearchScopePixel = false
							});
					}
				}
				ImageOriginal.ColumnCount = characterIndex;
			}
			ImageOriginal.RowCount = lineIndex;
		}
	}
}
