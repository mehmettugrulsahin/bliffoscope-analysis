using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http.Dispatcher;

namespace Bliffoscope.Analysis.Core.Infrastructure.IoC.AssemblyResolve
{
	public class AssemblyResolver : IAssembliesResolver
	{
		public ICollection<Assembly> GetAssemblies()
		{
			return AssemblyScanner.ApplicationAssemblies.ToList();
		}
	}
}
