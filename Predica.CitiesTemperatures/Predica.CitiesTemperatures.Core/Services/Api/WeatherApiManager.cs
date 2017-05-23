using System;
using System.IO;
using System.Threading.Tasks;
using Predica.CitiesTemperatures.Core.Infrastructure;
using Predica.CitiesTemperatures.Core.Models;
using Predica.CitiesTemperatures.Core.Services.Files;

namespace Predica.CitiesTemperatures.Core.Services.Api
{
	public class WeatherApiManager : IWeatherApiManager
	{
		private readonly string _configPath;
		private readonly IFileParserService _fileParserService;

		public WeatherApiManager(IFileParserService fileParserService)
		{
			_fileParserService = fileParserService;
			_configPath = Environment.ExpandEnvironmentVariables($"%AppData%\\{Consts.WeatherApiManagerPartPath}");
			var directory = Path.GetDirectoryName(_configPath);
			if (!Directory.Exists(directory))
			{
				Directory.CreateDirectory(directory);
			}
		}

		public async Task<bool> IsInRequestsLimit()
		{
			var config = await GetConfigFile();

			return config.RequestsCount < 60;
		}

		public async Task NextRequestFinished()
		{
			var config = await GetConfigFile();
			config.RequestsCount++;

			await _fileParserService.SaveObjectToFile<WeatherApiUsageInfo>(config, _configPath);
		}

		private async Task<WeatherApiUsageInfo> GetConfigFile()
		{
			var usageInfo = await _fileParserService.GetObjectFromFile<WeatherApiUsageInfo>(_configPath);
			if (usageInfo == null)
			{
				var config = new WeatherApiUsageInfo
				{
					FirstRequestDate = DateTime.UtcNow
				};

				usageInfo = await _fileParserService.SaveObjectToFile<WeatherApiUsageInfo>(config, _configPath);
			}

			return usageInfo;
		}
	}
}
