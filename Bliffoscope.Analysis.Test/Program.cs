using Bliffoscope.Analysis.Core.Infrastructure.IoC.AssemblyResolve;
using Bliffoscope.Analysis.Core.Infrastructure.IoC.Container;
using Bliffoscope.Analysis.Test.Analysis;
using Bliffoscope.Analysis.Test.IoC;
using Castle.MicroKernel.Lifestyle;

namespace Bliffoscope.Analysis.Test
{
	class Program
	{
		public static BliffoscopeAnalysisTest BliffoscopeAnalysisTest { get; set; }

		static void Main()
		{
			PrepareAnalysis();
			ExecuteAnalysis();
		}

		private static void PrepareAnalysis()
		{
			var thisAssembly = typeof(Program).Assembly;

			AssemblyScanner.Scan(thisAssembly);

			var container = CastleWindsorContainerBuilder
				.Build(thisAssembly, new ConsoleContainerInstaller());
			container.BeginScope();
			BliffoscopeAnalysisTest = container.Resolve<BliffoscopeAnalysisTest>();
		}

		private static void ExecuteAnalysis()
		{
			BliffoscopeAnalysisTest.Analyze();
		}
	}
}
