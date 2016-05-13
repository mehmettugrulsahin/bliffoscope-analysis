using System.Collections.Generic;

namespace Bliffoscope.Analysis.Core.Data
{
	public class Image
	{
		public int RowCount { get; set; }		
		public int RowImageStart { get; set; }
		public int RowImageEnd { get; set; }

		public int ColumnCount { get; set; }
		public int ColumnImageStart { get; set; }
		public int ColumnImageEnd { get; set; }

		public IList<Pixel> Pixels = new List<Pixel>();

		public string ImageType { get; set; }

	}
}
