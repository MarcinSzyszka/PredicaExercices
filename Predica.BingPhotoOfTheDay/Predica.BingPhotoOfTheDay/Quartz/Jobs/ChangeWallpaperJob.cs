using System;
using Predica.BingPhotoOfTheDay.Core.Services.Wallpaper;
using Quartz;

namespace Predica.BingPhotoOfTheDay.Quartz.Jobs
{
	public class ChangeWallpaperJob : IJob
	{
		private readonly IWalpaperService _wallpaperService;

		public ChangeWallpaperJob(IWalpaperService wallpaperService)
		{
			_wallpaperService = wallpaperService;
		}

		public void Execute(IJobExecutionContext context)
		{
			try
			{
				_wallpaperService.SetBingPhotoOfTheDayAsWallpaper();
			}
			catch (NotSupportedException exc)
			{
				Console.WriteLine(exc.Message);
			}
		}
	}
}
