using System.Reflection;
using Autofac;

namespace Predica.CitiesTemperatures.IoC
{
	public class Container
	{
		private readonly IContainer _container;

		public Container()
		{
			var containerBuilder = new ContainerBuilder();

			containerBuilder.RegisterAssemblyTypes(Assembly.Load(new AssemblyName("Predica.CitiesTemperatures.Core"))).AsImplementedInterfaces();

			_container = containerBuilder.Build();
		}

		public T Resolve<T>()
		{
			return _container.Resolve<T>();
		}
	}
}
