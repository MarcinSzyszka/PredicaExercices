using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Predica.CitiesTemperatures.Core.Services.Files
{
	public class FileParserService : IFileParserService
	{
		public async Task<T> GetObjectFromFile<T>(string path) where T : class
		{
			if (File.Exists(path))
			{
				string text;
				using (var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
				{
					using (var reader = new StreamReader(fileStream))
					{
						text = await reader.ReadToEndAsync();
					}
				}

				return JsonConvert.DeserializeObject<T>(text);
			}

			return default(T);
		}

		public async Task<T> SaveObjectToFile<T>(T objectToSave, string path) where T : class
		{
			var text = JsonConvert.SerializeObject(objectToSave, Formatting.None);

			using (var fileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite))
			{
				using (var writer = new StreamWriter(fileStream))
				{
					await writer.WriteAsync(text);
				}
			}

			return objectToSave;
		}
	}
}
