using System.Configuration;

namespace Bliffoscope.Analysis.Configure.Environment
{
	public class EnvironmentConfigurationElementCollection : ConfigurationElementCollection
	{
		protected override ConfigurationElement CreateNewElement()
		{
			return new EnvironmentConfigurationElement();
		}
		protected override object GetElementKey(ConfigurationElement element)
		{
			EnvironmentConfigurationElement customElement = element as EnvironmentConfigurationElement;

			if(customElement != null)
			{
				return customElement.Key;
			}

			return string.Empty;
		}

		public EnvironmentConfigurationElement this[int index]
		{
			get { return BaseGet(index) as EnvironmentConfigurationElement; }
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
