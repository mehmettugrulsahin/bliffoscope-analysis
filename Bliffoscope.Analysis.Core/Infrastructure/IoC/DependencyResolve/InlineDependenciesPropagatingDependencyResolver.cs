using System;
using Castle.MicroKernel.Context;
using Castle.MicroKernel.Resolvers;

namespace Bliffoscope.Analysis.Core.Infrastructure.IoC.DependencyResolve
{
	/// <summary>
	/// Represents a custom dependency resolver for propagating inline dependencies through the dependency stack
	/// </summary>
	public class InlineDependenciesPropagatingDependencyResolver : DefaultDependencyResolver
	{
		/// <summary>
		/// This method rebuild the context for the parameter type.
		/// Naive implementation.
		/// </summary>
		/// <param name="current"></param>
		/// <param name="parameterType"></param>
		/// <returns></returns>
		protected override CreationContext RebuildContextForParameter(CreationContext current, Type parameterType)
		{
			if(parameterType.ContainsGenericParameters)
				return current;
			return new CreationContext(parameterType, current, true);
		}
	}
}
