using System.Threading.Tasks;
using System.Web.Mvc;
using Predica.ODataService.Services.People;

namespace Predica.ODataService.Controllers
{
	public class HomeController : Controller
	{
		private readonly IODataPeopleService _oDataService;

		public HomeController(IODataPeopleService oDataService)
		{
			_oDataService = oDataService;
		}

		public async Task<ActionResult> Index()
		{
			var people = await _oDataService.GetPeople();

			return View(people);
		}

	}
}