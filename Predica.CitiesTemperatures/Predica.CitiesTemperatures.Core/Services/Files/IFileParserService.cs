using System.Threading.Tasks;

namespace Predica.CitiesTemperatures.Core.Services.Files
{
	public interface IFileParserService
	{
		Task<T> GetObjectFromFile<T>(string path) where T : class;
		Task<T> SaveObjectToFile<T>(T objectToSave, string path) where T : class;
	}
}