using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Predica.CitiesTemperatures.Core.Models;

namespace Predica.CitiesTemperatures.Core.Services.Api
{
	public class ApiCitiesTemperaturesService : IApiCitiesTemperaturesService
	{
		private const string AppBaseUrl = "http://api.openweathermap.org/data/2.5/";
		private const string CitesInCycleUrl = "find?lat=52.18&lon=21.00&cnt=50&units=metric&appid=6310acbdf85313300fad7559fbbe1785";
		private readonly HttpClient _client;

		public ApiCitiesTemperaturesService()
		{
			_client = new HttpClient { BaseAddress = new Uri(AppBaseUrl) };
		}

		public async Task<IEnumerable<CityTemperature>> GetCitiesTemperaturesList()
		{
			var resultList = new List<CityTemperature>();

			var response = await _client.GetAsync(CitesInCycleUrl);
			if (response.IsSuccessStatusCode)
			{
				var responseDataString = await response.Content.ReadAsStringAsync();

				var dynamicObjectResponse = JsonConvert.DeserializeObject<dynamic>(responseDataString);
				var citiesList = dynamicObjectResponse.list;

				if (citiesList != null)
				{
					foreach (var cityInfo in citiesList)
					{
						resultList.Add(new CityTemperature { CityName = cityInfo.name, Temperature = cityInfo.main.temp });
					}
				}
			}

			return resultList;
		}
	}
}
