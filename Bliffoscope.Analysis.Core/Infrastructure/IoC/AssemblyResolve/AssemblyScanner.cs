using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Castle.Core.Internal;

namespace Bliffoscope.Analysis.Core.Infrastructure.IoC.AssemblyResolve
{
	public class AssemblyScanner
	{
		private static List<Assembly> _applicationAssemblies = new List<Assembly>();
		private static bool _loaded;

		private static readonly object Synclock = new object();

		public static void Scan(Assembly applicationAssembly, string currentCustomizationsDirectory = null)
		{
			if(_loaded)
			{
				return;
			}

			lock (Synclock)
			{
				if(_loaded)
				{
					return;
				}

				_applicationAssemblies = new List<Assembly>();

				var directoryName = GetAssemblyDirectory();
				if(directoryName != null)
				{
					foreach(var current in GetFiles(directoryName))
					{
						AddApplicationAssembly(applicationAssembly, current);
					}
				}

				// Gets the customization assemblies
				if(currentCustomizationsDirectory != null)
				{
					foreach(var current in GetFiles(currentCustomizationsDirectory))
					{
						AddApplicationAssembly(applicationAssembly, current);
					}
				}

				_loaded = true;
			}
		}

		private static void AddApplicationAssembly(Assembly applicationAssembly, string current)
		{
			if(!ReflectionUtil.IsAssemblyFile(current))
			{
				return;
			}

			var assembly = LoadAssemblyIgnoringErrors(current);
			if(assembly == null)
			{
				return;
			}

			if(assembly == applicationAssembly || assembly.GetCustomAttribute<ApplicationScopeAttribute>() == null)
			{
				_applicationAssemblies.Add(assembly);
			}
		}

		public static IEnumerable<Assembly> ApplicationAssemblies
		{
			get { return _applicationAssemblies; }
		}

		private static IEnumerable<string> GetFiles(string directory)
		{
			IEnumerable<string> result;
			try
			{
				result = Directory.Exists(directory) ? Directory.EnumerateFiles(directory) : Enumerable.Empty<string>();
			}
			catch(IOException innerException)
			{
				throw new ArgumentException("Could not resolve assemblies.", innerException);
			}

			return result;
		}

		private static string GetAssemblyDirectory()
		{
			var codeBase = Assembly.GetExecutingAssembly().CodeBase;
			var uri = new UriBuilder(codeBase);
			var path = Uri.UnescapeDataString(uri.Path);

			return Path.GetDirectoryName(path);
		}

		private static Assembly LoadAssemblyIgnoringErrors(string file)
		{
			try
			{
				return ReflectionUtil.GetAssemblyNamed(file, t => true, a => true);
			}
			catch(FileNotFoundException) { }
			catch(FileLoadException) { }
			catch(BadImageFormatException) { }
			catch(ReflectionTypeLoadException) { }

			return null;
		}
	}
}