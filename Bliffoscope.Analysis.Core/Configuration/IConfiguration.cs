namespace Bliffoscope.Analysis.Core.Configuration
{
	public interface IConfiguration<T>
	{
		T GetConfigurationBlock();
	}
}
