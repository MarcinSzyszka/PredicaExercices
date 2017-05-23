using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.Win32;
using Predica.BingPhotoOfTheDay.Core.Services.Api;
using Predica.BingPhotoOfTheDay.Core.Services.OS;

namespace Predica.BingPhotoOfTheDay.Core.Services.Wallpaper
{
	public class WalpaperService : IWalpaperService
	{
		private readonly IBingApiService _bingApiService;
		private readonly IOsManager _osManager;
		private const uint SpiSetdeskwallpaper = 20;
		private const uint SpifUpdateinifile = 0x01;
		private const uint SpifSendwininichange = 0x02;

		public WalpaperService(IBingApiService bingApiService, IOsManager osManager)
		{
			_bingApiService = bingApiService;
			_osManager = osManager;
		}

		public async Task SetBingPhotoOfTheDayAsWallpaper()
		{
			if (!_osManager.DoesOsSupportWallpaperChange())
			{
				throw new NotSupportedException("This application is not supported in your version of OS. The minimum required version is Windows 7.");
			}

			var photoModel = await _bingApiService.GetPhotoOfTheDay();

			await SetDesktopWallpaper(photoModel.PhotoInBytes, photoModel.Name);
		}


		private async Task SetDesktopWallpaper(byte[] photoInBytes, string photoName)
		{
			RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);

			key.SetValue(@"WallpaperStyle", "10");
			key.SetValue(@"TileWallpaper", "0");

			key.Close();

			var pathToNewWallPaper = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Microsoft\Windows\Themes\", photoName);
			using (var ms = new MemoryStream(photoInBytes))
			{
				using (var fs = new FileStream(pathToNewWallPaper, FileMode.OpenOrCreate, FileAccess.ReadWrite))
				{
					await ms.CopyToAsync(fs);
				}
			}

			if (!SystemParametersInfo(SpiSetdeskwallpaper, 0, pathToNewWallPaper,
				SpifUpdateinifile | SpifSendwininichange))
			{
				throw new Win32Exception();
			}
		}

		[DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool SystemParametersInfo(uint uiAction, uint uiParam, string pvParam, uint fWinIni);
	}
}
