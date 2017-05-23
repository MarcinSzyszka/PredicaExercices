using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Predica.BingPhotoOfTheDay.Core.Models;

namespace Predica.BingPhotoOfTheDay.Core.Services.Api
{
	public class BingApiService : IBingApiService
	{
		private readonly HttpClient _client;
		private const string BingBaseUrl = "http://www.bing.com";
		private const string BingPfotoOfTheDayApiUrl = @"HPImageArchive.aspx?format=js&idx=0&n=1";

		public BingApiService()
		{
			_client = new HttpClient { BaseAddress = new Uri(BingBaseUrl) };
		}

		public async Task<BingPhotoOfTheDayModel> GetPhotoOfTheDay()
		{
			var resultModel = new BingPhotoOfTheDayModel();

			var photoUrl = await GetPhotoUrl();

			resultModel.Name = GetPhotoName(resultModel, photoUrl);

			if (!string.IsNullOrEmpty(photoUrl))
			{
				var photoResponse = await _client.GetAsync(photoUrl);
				if (photoResponse.IsSuccessStatusCode)
				{
					resultModel.PhotoInBytes = await photoResponse.Content.ReadAsByteArrayAsync();
				}
			}

			return resultModel;
		}

		private string GetPhotoName(BingPhotoOfTheDayModel resultModel, string photoUrl)
		{
			var lastSlashIndex = photoUrl.LastIndexOf("/", StringComparison.Ordinal);

			return photoUrl.Substring(lastSlashIndex, photoUrl.Length - lastSlashIndex).TrimStart('/');
		}

		private async Task<string> GetPhotoUrl()
		{
			var photoUrl = string.Empty;
			var photoOfTheDayInfoResponse = await _client.GetAsync(BingPfotoOfTheDayApiUrl);
			if (photoOfTheDayInfoResponse.IsSuccessStatusCode)
			{
				var photoOfTheDayInfoResponseString = await photoOfTheDayInfoResponse.Content.ReadAsStringAsync();
				var photoOfTheDayInfoObject = JsonConvert.DeserializeObject<dynamic>(photoOfTheDayInfoResponseString);

				photoUrl = photoOfTheDayInfoObject.images[0].url;
			}

			return photoUrl;
		}
	}
}
