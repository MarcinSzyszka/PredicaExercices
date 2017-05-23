using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Predica.CitiesTemperatures.Core.Infrastructure;
using Predica.CitiesTemperatures.Core.Models;
using Predica.CitiesTemperatures.Core.Services.Files;

namespace Predica.CitiesTemperatures.Core.Services.Temperatures
{
	public class SavedCitiesTemperaturesService : ISavedCitiesTemperaturesService
	{
		private readonly string _savedTemperaturesPath;
		private readonly IFileParserService _fileParserService;

		public SavedCitiesTemperaturesService(IFileParserService fileParserService)
		{
			_fileParserService = fileParserService;
			_savedTemperaturesPath = Environment.ExpandEnvironmentVariables($"%AppData%\\{Consts.SavedTemperaturesPartPath}");
			var directory = Path.GetDirectoryName(_savedTemperaturesPath);
			if (!Directory.Exists(directory))
			{
				Directory.CreateDirectory(directory);
			}
		}
		public async Task<IEnumerable<CityTemperature>> GetSavedCitiesTemperaturesList()
		{
			var savedList = await _fileParserService.GetObjectFromFile<IEnumerable<CityTemperature>>(_savedTemperaturesPath);

			return savedList ?? new List<CityTemperature>();
		}

		public async Task SaveCitiesTemperaturesList(IEnumerable<CityTemperature> resultList)
		{
			var saveObject = new SavedCitiesTemperatures
			{
				Tempratures = resultList
			};

			await _fileParserService.SaveObjectToFile<SavedCitiesTemperatures>(saveObject, _savedTemperaturesPath);
		}
	}
}