using System;
using System.Threading.Tasks;
using Moq;
using Predica.BingPhotoOfTheDay.Core.Services.Api;
using Predica.BingPhotoOfTheDay.Core.Services.OS;
using Predica.BingPhotoOfTheDay.Core.Services.Wallpaper;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Predica.BingPhotoOfTheDay.Core.Tests
{
	public class WalpaperServiceTests
	{
		[Fact]
		public async Task SetBingPhotoOfTheDayAsWalpaper_ShouldThrowNotSupportedException()
		{
			//Arrange
			_osManagerMock.Setup(s => s.DoesOsSupportWallpaperChange()).Returns(false);

			//Act
			//Assert
			await Assert.ThrowsExceptionAsync<NotSupportedException>(async () => await _serviceUnderTest.SetBingPhotoOfTheDayAsWallpaper());
		}
		#region CONFIGURATION

		private IWalpaperService _serviceUnderTest;
		private readonly Mock<IBingApiService> _bingApiServiceMock;
		private readonly Mock<IOsManager> _osManagerMock;

		public WalpaperServiceTests()
		{
			_osManagerMock = new Mock<IOsManager>();
			_bingApiServiceMock = new Mock<IBingApiService>();
			_serviceUnderTest = new WalpaperService(_bingApiServiceMock.Object, _osManagerMock.Object);
		}

		#endregion
	}
}