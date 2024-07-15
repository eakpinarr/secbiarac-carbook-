﻿using CarBook.DTO.BlogDtos;
using CarBook.DTO.CarPricingDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Controllers
{
	public class CarPricingController : Controller
	{

		private readonly IHttpClientFactory _httpClientFactory;

		public CarPricingController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			ViewBag.v1 = "Paketler";
			ViewBag.v2 = "Araç Fiyatları";
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7282/api/CarPricingsContoller/GetCarPricingWithTimePeriodList");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultCarPricingListWithModelDto>>(jsonData);
				return View(values);
			}
			return View();
		}
	}
}
