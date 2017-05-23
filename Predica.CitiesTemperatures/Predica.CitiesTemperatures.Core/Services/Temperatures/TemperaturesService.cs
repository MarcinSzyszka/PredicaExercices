using System.Collections.Generic;
using System.Threading.Tasks;
using Predica.CitiesTemperatures.Core.Models;
using Predica.CitiesTemperatures.Core.Services.Api;

namespace Predica.CitiesTemperatures.Core.Services.Temperatures
{
	public class TemperaturesService : ITemperaturesService
	{
		private readonly ISavedCitiesTemperaturesService _savedCitiesTemperaturesService;
		private readonly IWeatherApiManager _weatherApiManager;
		private readonly IApiCitiesTemperaturesService _apiCitiesTemperaturesService;

		public TemperaturesService(ISavedCitiesTemperaturesService savedCitiesTemperaturesService, IWeatherApiManager weatherApiManager, IApiCitiesTemperaturesService apiCitiesTemperaturesService)
		{
			_savedCitiesTemperaturesService = savedCitiesTemperaturesService;
			_weatherApiManager = weatherApiManager;
			_apiCitiesTemperaturesService = apiCitiesTemperaturesService;
		}

		public async Task<IEnumerable<CityTemperature>> GetTemperatures()
		{
			if (await _weatherApiManager.IsInRequestsLimit())
			{
				var resultList = await _apiCitiesTemperaturesService.GetCitiesTemperaturesList();
				await _savedCitiesTemperaturesService.SaveCitiesTemperaturesList(resultList);
				await _weatherApiManager.NextRequestFinished();

				return resultList;
			}
			else
			{
				return await _savedCitiesTemperaturesService.GetSavedCitiesTemperaturesList();
			}
		}
	}
}
