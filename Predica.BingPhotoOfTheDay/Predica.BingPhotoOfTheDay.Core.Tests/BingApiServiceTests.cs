using System.Threading.Tasks;
using Predica.BingPhotoOfTheDay.Core.Services.Api;
using Xunit;

namespace Predica.BingPhotoOfTheDay.Core.Tests
{
	public class BingApiServiceTests
	{

		[Fact]
		public async Task GetPhotoOfTheDay_ShouldCorrectModel_WithByteArrayAndPhotoName()
		{
			//Assert
			//Act
			var result = await _serviceUnderTest.GetPhotoOfTheDay();

			//Assert
			Assert.NotNull(result.PhotoInBytes);
			Assert.True(result.PhotoInBytes.Length > 0);
			Assert.NotNull(result.Name);
			Assert.Contains(".", result.Name);
		}
		#region CONFIGURATION
		readonly IBingApiService _serviceUnderTest;
		public BingApiServiceTests()
		{
			_serviceUnderTest = new BingApiService();
		}
		#endregion
	}
}
