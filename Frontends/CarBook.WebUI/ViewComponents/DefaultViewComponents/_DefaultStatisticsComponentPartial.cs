using CarBook.DTO.StatisticsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.DefaultViewComponents
{
	public class _DefaultStatisticsComponentPartial:ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _DefaultStatisticsComponentPartial (IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();

			#region AraçSayısıİstatistiği
			var responseMessage = await client.GetAsync("https://localhost:7282/api/Statistics/GetCarCount");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<ResultStatisricsDto>(jsonData);
				ViewBag.CarCount = values.CarCount;
			}
			#endregion AraçSayısıİstatistiği

			#region LokasyonSayısıİstatistiği
			var responseMessage2 = await client.GetAsync("https://localhost:7282/api/Statistics/GetLocationCount");
			if (responseMessage2.IsSuccessStatusCode)
			{
				var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
				var values2 = JsonConvert.DeserializeObject<ResultStatisricsDto>(jsonData2);
				ViewBag.LocationCount = values2.LocationCount;
			}
			#endregion LokasyonSayısıİstatistiği

			#region MarkaSayısıİstatistiği
			var responseMessage3 = await client.GetAsync("https://localhost:7282/api/Statistics/GetBrandCount");
			if (responseMessage3.IsSuccessStatusCode)
			{
				var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
				var values3 = JsonConvert.DeserializeObject<ResultStatisricsDto>(jsonData3);
				ViewBag.BrandCount = values3.BrandCount;
			}
			#endregion MarkaSayısıİstatistiği

			#region ElektrikliAraçSayısı
			var responseMessage4 = await client.GetAsync("https://localhost:7282/api/Statistics/GetCarCountByFuelElectric");
			if (responseMessage4.IsSuccessStatusCode)
			{
				var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
				var values4 = JsonConvert.DeserializeObject<ResultStatisricsDto>(jsonData4);
				ViewBag.CarCountByFuelElectric = values4.CarCountByFuelElectric;
			}
			#endregion ElektrikliAraçSayısı
			return View();
		}
	}
}
