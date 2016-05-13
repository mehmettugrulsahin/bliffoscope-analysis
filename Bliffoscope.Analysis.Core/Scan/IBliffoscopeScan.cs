using Bliffoscope.Analysis.Core.Data;

namespace Bliffoscope.Analysis.Core.Scan
{
	public interface IBliffoscopeScan<T> : IScan<T> where T : Image
	{
		void SetImage(string bliffoscopeData);
	}
}
