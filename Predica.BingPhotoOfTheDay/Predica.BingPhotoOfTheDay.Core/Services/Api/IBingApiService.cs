using System.Threading.Tasks;
using Predica.BingPhotoOfTheDay.Core.Models;

namespace Predica.BingPhotoOfTheDay.Core.Services.Api
{
	public interface IBingApiService
	{
		Task<BingPhotoOfTheDayModel> GetPhotoOfTheDay();
	}
}