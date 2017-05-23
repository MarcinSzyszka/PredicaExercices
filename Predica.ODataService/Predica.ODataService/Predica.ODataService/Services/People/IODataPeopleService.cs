using System.Collections.Generic;
using System.Threading.Tasks;
using Predica.ODataService.ViewModels;

namespace Predica.ODataService.Services.People
{
	public interface IODataPeopleService
	{
		Task<IEnumerable<Person>> GetPeople();
	}
}