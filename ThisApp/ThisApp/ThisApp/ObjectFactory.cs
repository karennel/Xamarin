using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ThisApp
{
	public static class ObjectFactory
	{
		static StandardKernel _container;

		public static void Initialize(IEnumerable<INinjectModule> modules = null)
		{
			var allModules = modules.IsNullOrEmpty() ? new List<INinjectModule>() : new List<INinjectModule>(modules);

			_container = new StandardKernel(allModules.ToArray());
		}

		public static T Get<T>()
		{
			EnsureIntialized();

			return _container.Get<T>();
		}

		public static async Task<T> GetAsync<T>()
		{
			EnsureIntialized();

			return await Task.Run(() => _container.Get<T>());
		}

		public static object Get(Type type)
		{
			EnsureIntialized();

			return _container.Get(type);
		}

		static void EnsureIntialized()
		{
			if (_container == null)
				throw new InvalidOperationException("Not initialized.");
		}

		public static void Dispose()
		{
			EnsureIntialized();

			_container.Dispose();
			_container = null;
		}
	}
}