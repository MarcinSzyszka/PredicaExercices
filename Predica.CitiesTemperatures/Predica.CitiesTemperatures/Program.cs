using System;
using System.Threading.Tasks;
using Predica.CitiesTemperatures.IoC;
using System.Linq;
using Predica.CitiesTemperatures.Core.Services.Temperatures;

namespace Predica.CitiesTemperatures
{
	class Program
	{
		static void Main(string[] args)
		{
			var container = new Container();
			var temperaturesService = container.Resolve<ITemperaturesService>();

			Task.Factory.StartNew(async () =>
			{
				var temperatures = await temperaturesService.GetTemperatures();

				var orderedTempratures = temperatures.OrderByDescending(c => c.Temperature);

				foreach (var city in orderedTempratures)
				{
					Console.WriteLine($"{city.CityName} - {city.Temperature} C");
				}
			});

			Console.ReadKey();
		}
	}
}