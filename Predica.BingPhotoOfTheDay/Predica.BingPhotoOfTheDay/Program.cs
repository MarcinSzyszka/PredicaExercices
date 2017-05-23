using System;
using System.Threading;
using System.Threading.Tasks;
using Predica.BingPhotoOfTheDay.Core.Services.Wallpaper;
using Predica.BingPhotoOfTheDay.IoC;
using Predica.BingPhotoOfTheDay.Quartz;
using Predica.BingPhotoOfTheDay.Quartz.Jobs;
using Quartz;
using Quartz.Impl;

namespace Predica.BingPhotoOfTheDay
{
	class Program
	{
		static void Main(string[] args)
		{
			var schedulerFactory = new StdSchedulerFactory();
			var scheduler = schedulerFactory.GetScheduler();
			scheduler.JobFactory = new CustomJobFactory();
			scheduler.Start();

			var trigger = TriggerBuilder.Create().StartNow()
				.WithDailyTimeIntervalSchedule(x => x
					.OnEveryDay()
					.WithIntervalInHours(24)).Build();

			var changeWallpaperJob = JobBuilder.Create<ChangeWallpaperJob>().Build();
			scheduler.ScheduleJob(changeWallpaperJob, trigger);

			Console.ReadLine();
		}
	}
}
