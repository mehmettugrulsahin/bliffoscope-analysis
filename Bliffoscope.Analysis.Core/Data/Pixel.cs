namespace Bliffoscope.Analysis.Core.Data
{
	public class Pixel
	{
		public int Row { get; set; }
		public int Column { get; set; }

		public char OriginalValue { get; set; }

		public bool MarkedTemporary { get; set; }
		public char MarkedTemporaryValue { get; set; }
		public bool MarkedPermanent { get; set; }
		public char MarkedPermanentValue { get; set; }

		public bool SearchScopePixel { get; set; }
	}
}
