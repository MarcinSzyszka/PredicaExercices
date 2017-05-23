using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Predica.ODataService.ViewModels;


namespace Predica.ODataService.Services.People
{
	public class ODataPeopleService : IODataPeopleService
	{
		readonly IODataBaseService<Models.People> _oDataBaseService;

		public ODataPeopleService(IODataBaseService<Models.People> oDataBaseService)
		{
			_oDataBaseService = oDataBaseService;
		}

		public async Task<IEnumerable<Person>> GetPeople()
		{
			var resultList = new List<Person>();

			var people = await _oDataBaseService.GetCollection()
				.Select(p => new
				{
					UserName = p.UserName,
					FirstName = p.FirstName,
					LastName = p.LastName,
					Gender = p.Gender,
					Emails = p.Emails
				})
				.FindEntriesAsync();

			foreach (var man in people)
			{
				resultList.Add(new Person
				{
					UserName = man.UserName,
					FirstName = man.FirstName,
					LastName = man.LastName,
					Gender = man.Gender,
					DefaultEmail = man.Emails.FirstOrDefault() ?? string.Empty
				});
			}

			return resultList;
		}
	}
}