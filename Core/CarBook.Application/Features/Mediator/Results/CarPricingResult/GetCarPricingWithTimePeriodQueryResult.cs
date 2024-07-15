using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Results.CarPricingResult
{
	public class GetCarPricingWithTimePeriodQueryResult
	{
		public string Model { get; set; }
		public decimal DailyAmount { get; set; }
		public decimal WeeklyAmount { get; set; }
		public decimal MonthlyAmount { get; set; }
		public string CoverImageURL { get; set; }
		public string Brand { get; set; }
	}
}
