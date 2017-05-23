using System.Threading.Tasks;

namespace Predica.BingPhotoOfTheDay.Core.Services.Wallpaper
{
	public interface IWalpaperService
	{
		Task SetBingPhotoOfTheDayAsWallpaper();
	}
}