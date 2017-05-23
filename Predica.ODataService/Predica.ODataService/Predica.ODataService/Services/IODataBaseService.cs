using Predica.ODataService.Models;
using Simple.OData.Client;

namespace Predica.ODataService.Services
{
	public interface IODataBaseService<T> where T : ODataEntityBase
	{
		IBoundClient<T> GetCollection();
	}
}