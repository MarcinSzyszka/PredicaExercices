using System.Collections.Generic;
using System.Threading.Tasks;
using Predica.CitiesTemperatures.Core.Models;

namespace Predica.CitiesTemperatures.Core.Services.Temperatures
{
	public interface ISavedCitiesTemperaturesService
	{
		Task<IEnumerable<CityTemperature>> GetSavedCitiesTemperaturesList();
		Task SaveCitiesTemperaturesList(IEnumerable<CityTemperature> resultList);
	}
}