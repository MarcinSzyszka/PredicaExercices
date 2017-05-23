using System.Collections.Generic;
using System.Threading.Tasks;
using Predica.CitiesTemperatures.Core.Models;

namespace Predica.CitiesTemperatures.Core.Services.Api
{
	public interface IApiCitiesTemperaturesService
	{
		Task<IEnumerable<CityTemperature>> GetCitiesTemperaturesList();
	}
}