using System;

namespace Predica.CitiesTemperatures.Core.Models
{
	internal class WeatherApiUsageInfo
	{
		public DateTime FirstRequestDate { get; set; }
		public int RequestsCount { get; set; }
	}
}
