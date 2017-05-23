using System;
using Predica.BingPhotoOfTheDay.IoC;
using Quartz;
using Quartz.Spi;

namespace Predica.BingPhotoOfTheDay.Quartz
{
	internal class CustomJobFactory : IJobFactory
	{
		private readonly Container _container;

		public CustomJobFactory()
		{
			_container = new Container();
		}
		public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
		{
			return _container.IoCContainer.Resolve(bundle.JobDetail.JobType) as IJob;
		}

		public void ReturnJob(IJob job)
		{
			(job as IDisposable)?.Dispose();
		}
	}
}
