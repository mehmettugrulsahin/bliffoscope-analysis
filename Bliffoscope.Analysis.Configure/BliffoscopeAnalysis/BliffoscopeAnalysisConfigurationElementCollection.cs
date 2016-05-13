using System.Configuration;

namespace Bliffoscope.Analysis.Configure.BliffoscopeAnalysis
{
	public class BliffoscopeAnalysisConfigurationElementCollection : ConfigurationElementCollection
	{
		protected override ConfigurationElement CreateNewElement()
		{
			return new BliffoscopeAnalysisConfigurationElement();
		}
		protected override object GetElementKey(ConfigurationElement element)
		{
			BliffoscopeAnalysisConfigurationElement customElement = element as BliffoscopeAnalysisConfigurationElement;

			if(customElement != null)
			{
				return customElement.Key;
			}

			return string.Empty;
		}

		public BliffoscopeAnalysisConfigurationElement this[int index]
		{
			get { return BaseGet(index) as BliffoscopeAnalysisConfigurationElement; }
			set
			{
				if(BaseGet(index) != null)
				{
					BaseRemoveAt(index);
				}

				BaseAdd(index, value);
			}
		}
	}
}
