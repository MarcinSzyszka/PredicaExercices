using System.Linq;
using System.Threading.Tasks;
using Predica.ODataService.Models;
using Predica.ODataService.Services;
using Predica.ODataService.Services.People;
using Xunit;

namespace Predica.ODataService.Tests
{
	public class ODataPeopleServiceTests
	{
		[Fact]
		public async Task GetPeople_ShoulReturnListWitthPersonObjects()
		{
			//Arrange
			var oneOfPeopleUserName = "russellwhyte";

			//Act
			var result = await _serviceUnderTest.GetPeople();

			//Assert
			Assert.NotNull(result);
			Assert.True(result.Any());
			Assert.True(result.Any(p => p.UserName == oneOfPeopleUserName));
		}

		#region CONFIGURATION

		private readonly IODataPeopleService _serviceUnderTest;

		public ODataPeopleServiceTests()
		{
			_serviceUnderTest = new ODataPeopleService(new ODataBaseService<People>());
		}

		#endregion
	}
}
