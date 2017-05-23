using System.Threading.Tasks;

namespace Predica.CitiesTemperatures.Core.Services.Api
{
	public interface IWeatherApiManager
	{
		Task<bool> IsInRequestsLimit();
		Task NextRequestFinished();
	}
}