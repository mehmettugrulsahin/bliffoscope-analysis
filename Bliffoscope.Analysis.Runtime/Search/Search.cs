using System.Collections.Generic;
using System.IO;
using System.Linq;
using Bliffoscope.Analysis.Core.Configuration;
using Bliffoscope.Analysis.Core.Constant;
using Bliffoscope.Analysis.Core.Data;
using Bliffoscope.Analysis.Core.Domain.Configuration;
using Bliffoscope.Analysis.Core.Model;
using Bliffoscope.Analysis.Core.Scan;

namespace Bliffoscope.Analysis.Runtime.Search
{
	public class Search
	{
		protected ConfigurationBlock ConfigurationBlock { get; private set; }
		protected EnvironmentSettings EnvironmentSettings { get; private set; }

		private readonly IConfiguration<ConfigurationBlock> _configuration;

		public IScan<BliffoscopeData> BliffoscopeDataScan { get; private set; }

		public int MatchPercentage { get; private set; }

		public string TargetsFoundTextImage { get; set; }
		public IList<Target> TargetsFound { get; set; }

		public Search(IConfiguration<ConfigurationBlock> configuration)
		{
			_configuration = configuration;

			GetConfigurationBlock();
			GetEnvironmentSettings();
		}

		private void GetConfigurationBlock()
		{
			ConfigurationBlock = _configuration.GetConfigurationBlock();
		}

		private void GetEnvironmentSettings()
		{
			EnvironmentSettings = ConfigurationBlock.EnvironmentSettings;
		}

		public void SetBliffoscopeDataScan(IScan<BliffoscopeData> bliffoscopeDataScan)
		{
			BliffoscopeDataScan = bliffoscopeDataScan;
		}

		public void SetMatchPercentage(int matchPercentage)
		{
			MatchPercentage = matchPercentage;
		}

		public void SetBliffoscopeDataSearchScope<T>(IScan<T> targetScan) where T : Image
		{
			foreach(var pixel in BliffoscopeDataScan.Image.Pixels)
			{
				if(pixel.Row + targetScan.Image.RowCount <= BliffoscopeDataScan.Image.RowCount &&
					pixel.Column + targetScan.Image.ColumnCount <= BliffoscopeDataScan.Image.ColumnCount)
				{
					pixel.SearchScopePixel = true;
				}
			}
		}

		public void AcquireTargets<T>(IScan<T> targetScan) where T : Image
		{
			TargetsFound = new List<Target>();

			foreach(var cursorPixel in BliffoscopeDataScan.Image.Pixels.Where(p => p.MarkedPermanent || p.MarkedTemporary))
			{
				cursorPixel.MarkedPermanent = false;
				cursorPixel.MarkedPermanentValue = cursorPixel.OriginalValue;

				cursorPixel.MarkedTemporary = false;
				cursorPixel.MarkedTemporaryValue = cursorPixel.OriginalValue;
			}

			foreach(var cursorPixel in BliffoscopeDataScan.Image.Pixels.Where(p => p.SearchScopePixel))
			{
				// get bliffoscope data surface to compare
				IList<Pixel> comparedBliffoscopeDataSurface = BliffoscopeDataScan.Image.Pixels
					.Where(p => p.Row >= cursorPixel.Row &&
								p.Row < cursorPixel.Row + targetScan.Image.RowCount &&
								p.Column >= cursorPixel.Column &&
								p.Column < cursorPixel.Column + targetScan.Image.ColumnCount).ToList();

				// compare bliffoscope data surface pixels with target image pixels
				foreach(var comparedBliffoscopeDataPixel in comparedBliffoscopeDataSurface)
				{
					// get target pixel to compare with
					var comparedtargetPixel = targetScan.Image.Pixels
						.First(p => p.Row == comparedBliffoscopeDataPixel.Row - cursorPixel.Row &&
									p.Column == comparedBliffoscopeDataPixel.Column - cursorPixel.Column);

					// compare pixels and mark if they match
					if(comparedBliffoscopeDataPixel.OriginalValue == comparedtargetPixel.OriginalValue && comparedtargetPixel.OriginalValue == '+')
					{
						comparedBliffoscopeDataPixel.MarkedTemporary = true;
						comparedBliffoscopeDataPixel.MarkedTemporaryValue = BliffoscopeAnalysisConstants.MarkedTemporaryValue;
					}
				}

				// apply marked values from compare surface to actual bliffoscope data if match percentage is above minimum expected
				if((decimal)comparedBliffoscopeDataSurface.Count(p => p.MarkedTemporary) / comparedBliffoscopeDataSurface.Count() * 100 >= MatchPercentage)
				{
					foreach(var comparedBliffoscopeDataPixel in comparedBliffoscopeDataSurface.Where(p => p.MarkedTemporary))
					{
						var targetPixel = BliffoscopeDataScan.Image.Pixels
							.First(p => p.Row == comparedBliffoscopeDataPixel.Row &&
										p.Column == comparedBliffoscopeDataPixel.Column);

						targetPixel.MarkedPermanent = comparedBliffoscopeDataPixel.MarkedTemporary;
						targetPixel.MarkedPermanentValue = comparedBliffoscopeDataPixel.MarkedTemporaryValue;
					}

					TargetsFound.Add(
						new Target
						{
							TargetType = targetScan.Image.ImageType,
							Row = cursorPixel.Row,
							Column = cursorPixel.Column
						});
				}
			}

			MakeTargetsFoundTextImage();
		}

		private void MakeTargetsFoundTextImage()
		{
			TargetsFoundTextImage = string.Empty;

			for(int row = 0; row < BliffoscopeDataScan.Image.RowCount; row++)
			{
				string line = new string(BliffoscopeDataScan.Image.Pixels
					.Where(p => p.Row == row &&
								p.Column >= 0 && p.Column < BliffoscopeDataScan.Image.ColumnCount)
					.Select(l => l.OriginalValue == l.MarkedPermanentValue ? l.OriginalValue : l.MarkedPermanentValue).ToArray());

				TargetsFoundTextImage = string.Concat(TargetsFoundTextImage, '\n', line);
			}
			TargetsFoundTextImage = TargetsFoundTextImage.Substring(2);
		}

		public void ExtractTargets(string path, string fileName)
		{
			string file = Path.Combine(path, fileName);

			if(File.Exists(file))
			{
				File.Delete(file);
			}

			if(!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}

			var myFile = File.Create(file);
			myFile.Close();

			StreamWriter targets = new StreamWriter(file);

			for(int row = 0; row < BliffoscopeDataScan.Image.RowCount; row++)
			{
				string line = new string(BliffoscopeDataScan.Image.Pixels
					.Where(p => p.Row == row &&
								p.Column >= 0 && p.Column < BliffoscopeDataScan.Image.ColumnCount)
					.Select(l => l.OriginalValue == l.MarkedPermanentValue ? l.OriginalValue : l.MarkedPermanentValue).ToArray());

				targets.WriteLine(line);
			}

			targets.Close();
		}
	}
}
