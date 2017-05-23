using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace Predica.BingPhotoOfTheDay.IoC
{
	public class Container
	{
		public IWindsorContainer IoCContainer { get; private set; }

		public Container()
		{
			IoCContainer = new WindsorContainer();
			IoCContainer.Register(Classes.FromAssemblyNamed("Predica.BingPhotoOfTheDay.Core")
				.Where(type => type.Name.EndsWith("Service"))
				.WithService.DefaultInterfaces()
				.LifestyleTransient());

			IoCContainer.Register(Classes.FromAssemblyNamed("Predica.BingPhotoOfTheDay.Core")
				.Where(type => type.Name.EndsWith("Manager"))
				.WithService.DefaultInterfaces()
				.LifestyleTransient());

			IoCContainer.Register(Classes.FromThisAssembly()
				.Where(type => type.Name.EndsWith("Job"))
				.WithService.Self()
				.LifestyleTransient());
		}
	}
}
