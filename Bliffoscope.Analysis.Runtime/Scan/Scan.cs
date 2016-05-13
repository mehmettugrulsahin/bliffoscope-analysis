using Bliffoscope.Analysis.Core.Configuration;
using Bliffoscope.Analysis.Core.Data;
using Bliffoscope.Analysis.Core.Domain.Configuration;
using System.IO;
using System.Linq;

namespace Bliffoscope.Analysis.Runtime.Scan
{
	public class Scan
	{
		private readonly IConfiguration<ConfigurationBlock> _configuration;

		protected ConfigurationBlock ConfigurationBlock { get; private set; }
		protected EnvironmentSettings EnvironmentSettings { get; private set; }

		private string _filePath;
		private string _fileName;
		private StreamReader _fileReader;

		protected Image ImageOriginal;
		public Image Image { get; private set; }

		public Scan(IConfiguration<ConfigurationBlock> configuration)
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

		public void SetFileReader(string filePath, string fileName)
		{
			_filePath = filePath;
			_fileName = fileName;
			_fileReader = new StreamReader(Path.Combine(filePath, fileName));
		}

		public void GetImageOriginal()
		{
			int lineIndex = 0;
			while(!_fileReader.EndOfStream)
			{
				string line = _fileReader.ReadLine();
				int characterIndex = 0;
				if (line != null)
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
				lineIndex++;
			}
			ImageOriginal.RowCount = lineIndex;
		}

		protected void SetImageWithNoWhiteSpaceAround()
		{
			Image = new Image
			{
				RowCount = ImageOriginal.RowImageEnd - ImageOriginal.RowImageStart + 1,
				ColumnCount = ImageOriginal.ColumnImageEnd - ImageOriginal.ColumnImageStart + 1,

				RowImageStart = 0,
				RowImageEnd = ImageOriginal.RowImageEnd - ImageOriginal.RowImageStart,

				ColumnImageStart = 0,
				ColumnImageEnd = ImageOriginal.ColumnImageEnd - ImageOriginal.ColumnImageStart,

				Pixels =
					ImageOriginal
						.Pixels
						.Where(p => p.Row >= ImageOriginal.RowImageStart &&
									p.Row <= ImageOriginal.RowImageEnd)
						.ToList(), 

				ImageType = ImageOriginal.ImageType
			};

			foreach (var pixel in Image.Pixels)
			{
				pixel.Row = pixel.Row - ImageOriginal.RowImageStart;
				pixel.Column = pixel.Column - ImageOriginal.ColumnImageStart;
			}
		}
	}
}
