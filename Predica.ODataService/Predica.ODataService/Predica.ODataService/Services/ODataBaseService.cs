using Predica.ODataService.Models;
using Simple.OData.Client;

namespace Predica.ODataService.Services
{
	public class ODataBaseService<T> : IODataBaseService<T> where T : ODataEntityBase
	{
		private const string OdataServiceUrl = @"http://services.odata.org/v4/TripPinServiceRW/";

		public IBoundClient<T> GetCollection()
		{
			var client = new ODataClient(OdataServiceUrl);
			
			return client.For<T>();
		}
	}
}