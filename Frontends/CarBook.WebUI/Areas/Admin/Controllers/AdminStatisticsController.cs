using CarBook.DTO.AuthorDtos;
using CarBook.DTO.StatisticsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminStatistics")]
    public class AdminStatisticsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminStatisticsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            #region AraçSayısıİstatistiği
            var responseMessage = await client.GetAsync("https://localhost:7282/api/Statistics/GetCarCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisricsDto>(jsonData);
                ViewBag.v = values.CarCount;
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
            #region YazarSayısıİstatistiği
            var responseMessage3 = await client.GetAsync("https://localhost:7282/api/Statistics/GetAuthorCount");
            if (responseMessage3.IsSuccessStatusCode)
            {
                var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
                var values3 = JsonConvert.DeserializeObject<ResultStatisricsDto>(jsonData3);
                ViewBag.AuthorCount = values3.AuthorCount;
            }
            #endregion YazarSayısıİstatistiği
            #region BlogSayısıİstatistiği
            var responseMessage4 = await client.GetAsync("https://localhost:7282/api/Statistics/GetBlogCount");
            if (responseMessage4.IsSuccessStatusCode)
            {
                var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
                var values4 = JsonConvert.DeserializeObject<ResultStatisricsDto>(jsonData4);
                ViewBag.BlogCount = values4.BlogCount;
            }
            #endregion BlogSayısıİstatistiği
            #region MarkaSayısıİstatistiği
            var responseMessage5 = await client.GetAsync("https://localhost:7282/api/Statistics/GetBrandCount");
            if (responseMessage5.IsSuccessStatusCode)
            {
                var jsonData5 = await responseMessage5.Content.ReadAsStringAsync();
                var values5 = JsonConvert.DeserializeObject<ResultStatisricsDto>(jsonData5);
                ViewBag.BrandCount = values5.BrandCount;
            }
            #endregion MarkaSayısıİstatistiği
            #region AraçlarınGünlükFiyatOrtalaması
            var responseMessage6 = await client.GetAsync("https://localhost:7282/api/Statistics/GetAvgRentPriceForDaily");
            if (responseMessage6.IsSuccessStatusCode)
            {
                var jsonData6 = await responseMessage6.Content.ReadAsStringAsync();
                var values6 = JsonConvert.DeserializeObject<ResultStatisricsDto>(jsonData6);
                ViewBag.AvgRentPriceForDaily = values6.AvgRentPriceForDaily.ToString("0.00");
            }
            #endregion AraçlarınGünlükFiyatOrtalaması
            #region AraçlarınHaftalıkFiyatOrtalaması
            var responseMessage7 = await client.GetAsync("https://localhost:7282/api/Statistics/GetAvgRentPriceForWeekly");
            if (responseMessage7.IsSuccessStatusCode)
            {
                var jsonData7 = await responseMessage7.Content.ReadAsStringAsync();
                var values7 = JsonConvert.DeserializeObject<ResultStatisricsDto>(jsonData7);
                ViewBag.AvgRentPriceForWeekly = values7.AvgRentPriceForWeekly.ToString("0.00");
            }
            #endregion AraçlarınHaftalıkFiyatOrtalaması
            #region AraçlarınAylıkFiyatOrtalaması
            var responseMessage8 = await client.GetAsync("https://localhost:7282/api/Statistics/GetAvgRentPriceForMonthly");
            if (responseMessage8.IsSuccessStatusCode)
            {
                var jsonData8 = await responseMessage8.Content.ReadAsStringAsync();
                var values8 = JsonConvert.DeserializeObject<ResultStatisricsDto>(jsonData8);
                ViewBag.AvgRentPriceForMonthly = values8.AvgRentPriceForMonthly.ToString("0.00");
            }
            #endregion AraçlarınAylıkFiyatOrtalaması
            #region OtomatikVitesliAraçlarınSayısı
            var responseMessage9 = await client.GetAsync("https://localhost:7282/api/Statistics/GetCarCountByTransmissionIsAuto");
            if (responseMessage9.IsSuccessStatusCode)
            {
                var jsonData9 = await responseMessage9.Content.ReadAsStringAsync();
                var values9 = JsonConvert.DeserializeObject<ResultStatisricsDto>(jsonData9);
                ViewBag.CarCountByTransmissionIsAuto = values9.CarCountByTransmissionIsAuto;
            }
            #endregion OtomatikVitesliAraçlarınSayısı
            #region Km'si 1000den az olan araç sayısı
            var responseMessage10 = await client.GetAsync("https://localhost:7282/api/Statistics/GetCarCountByKmSmallerThen1000");
            if (responseMessage10.IsSuccessStatusCode)
            {
                var jsonData10 = await responseMessage10.Content.ReadAsStringAsync();
                var values10 = JsonConvert.DeserializeObject<ResultStatisricsDto>(jsonData10);
                ViewBag.CarCountByKmSmallerThen1000 = values10.CarCountByKmSmallerThen1000;
            }
            #endregion m'si 1000den az olan araç sayısı
            #region DizelYadaBenzinliAraçlarınSayısı
            var responseMessage11 = await client.GetAsync("https://localhost:7282/api/Statistics/GetCarCountByFuelGasolineOrDiesel");
            if (responseMessage11.IsSuccessStatusCode)
            {
                var jsonData11 = await responseMessage11.Content.ReadAsStringAsync();
                var values11 = JsonConvert.DeserializeObject<ResultStatisricsDto>(jsonData11);
                ViewBag.CarCountByFuelGasolineOrDiesel = values11.CarCountByFuelGasolineOrDiesel;
            }
            #endregion DizelYadaBenzinliAraçlarınSayısı
            #region ElektrikliAraçSayısı
            var responseMessage12 = await client.GetAsync("https://localhost:7282/api/Statistics/GetCarCountByFuelElectric");
            if (responseMessage12.IsSuccessStatusCode)
            {
                var jsonData12 = await responseMessage12.Content.ReadAsStringAsync();
                var values12 = JsonConvert.DeserializeObject<ResultStatisricsDto>(jsonData12);
                ViewBag.CarCountByFuelElectric = values12.CarCountByFuelElectric;
            }
            #endregion ElektrikliAraçSayısı
            #region Kiralama Ücreti En Pahalı Araç
            var responseMessage13 = await client.GetAsync("https://localhost:7282/api/Statistics/GetCarBrandAndModelByRentPriceDailyMax");
            if (responseMessage13.IsSuccessStatusCode)
            {
                var jsonData13 = await responseMessage13.Content.ReadAsStringAsync();
                var values13 = JsonConvert.DeserializeObject<ResultStatisricsDto>(jsonData13);
                ViewBag.CarBrandAndModelByRentPriceDailyMax = values13.CarBrandAndModelByRentPriceDailyMax;
            }
            #endregion Kiralama Ücreti En Pahalı Araç
            #region Kiralama Ücreti En Ucuz Araç
            var responseMessage14 = await client.GetAsync("https://localhost:7282/api/Statistics/GetCarBrandAndModelByRentPriceDailyMin");
            if (responseMessage14.IsSuccessStatusCode)
            {
                var jsonData14 = await responseMessage14.Content.ReadAsStringAsync();
                var values14 = JsonConvert.DeserializeObject<ResultStatisricsDto>(jsonData14);
                ViewBag.CarBrandAndModelByRentPriceDailyMin = values14.CarBrandAndModelByRentPriceDailyMin;
                
            }
            #endregion Kiralama Ücreti En Ucuz Araç
            #region En Çok Yorum Alan Blog
            var responseMessage15 = await client.GetAsync("https://localhost:7282/api/Statistics/GetBlogTitleByMaxBlogComment");
            if (responseMessage15.IsSuccessStatusCode)
            {
                var jsonData15 = await responseMessage15.Content.ReadAsStringAsync();
                var values15 = JsonConvert.DeserializeObject<ResultStatisricsDto>(jsonData15);
                ViewBag.BlogTitleByMaxBlogComment = values15.BlogTitleByMaxBlogComment;
            }
            #endregion En Çok Yorum Alan Blog
            #region En Fazla Modele Sahip Araç
            var responseMessage16 = await client.GetAsync("https://localhost:7282/api/Statistics/GetBrandNameByMaxCar");
            if (responseMessage16.IsSuccessStatusCode)
            {
                var jsonData16 = await responseMessage16.Content.ReadAsStringAsync();
                var values16 = JsonConvert.DeserializeObject<ResultStatisricsDto>(jsonData16);
                ViewBag.BrandNameByMaxCar = values16.BrandNameByMaxCar;
            }
            #endregion En Fazla Modele Sahip Araç

            return View();
        }
    }
}