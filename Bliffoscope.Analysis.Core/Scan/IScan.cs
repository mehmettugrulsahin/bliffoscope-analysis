using Bliffoscope.Analysis.Core.Data;

namespace Bliffoscope.Analysis.Core.Scan
{
	public interface IScan<T> where T : Image
	{
		Image Image { get; }		
	}
}
