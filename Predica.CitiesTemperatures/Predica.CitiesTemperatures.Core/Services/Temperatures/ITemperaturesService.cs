using System.Collections.Generic;
using System.Threading.Tasks;
using Predica.CitiesTemperatures.Core.Models;

namespace Predica.CitiesTemperatures.Core.Services.Temperatures
{
	public interface ITemperaturesService
	{
		Task<IEnumerable<CityTemperature>> GetTemperatures();
	}
}