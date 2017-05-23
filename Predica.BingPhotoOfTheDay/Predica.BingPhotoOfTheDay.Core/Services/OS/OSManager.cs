using System;

namespace Predica.BingPhotoOfTheDay.Core.Services.OS
{
	public class OsManager : IOsManager
	{
		public bool DoesOsSupportWallpaperChange()
		{
			return Environment.OSVersion.Version >= new Version(6, 1);
		}
	}
}