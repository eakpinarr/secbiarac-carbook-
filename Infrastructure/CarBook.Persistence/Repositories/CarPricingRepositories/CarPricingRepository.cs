using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Application.Interfaces.CarPricingInterfaces;
using CarBook.Application.ViewModels;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.CarPricingRepositories
{
	public class CarPricingRepository : ICarPricingRepository
	{
		private readonly CarBookContext _context;
		public CarPricingRepository(CarBookContext context)
		{
			_context = context;
		}
		public List<CarPricing> GetCarPricingWithCars()
		{
			var values = _context.CarPricings.Include(x=>x.Car).ThenInclude(y=>y.Brand).Include(x=>x.Pricing).Where(z=>z.PricingID==4).ToList();
			return values;
		}

		public List<CarPricing> GetCarPricingWithTimePeriod()
		{
			throw new NotImplementedException();
		}

		public List<CarPricingViewModel> GetCarPricingWithTimePeriod1()
		{
			List<CarPricingViewModel> values = new List<CarPricingViewModel>();
			using (var command = _context.Database.GetDbConnection().CreateCommand())
			{
				command.CommandText = "Select * From (Select Model,BrandName,CoverImageUrl,PricingID,Amount From CarPricings Inner Join Cars On Cars.CarID=CarPricings.CarId Inner Join Brands On Brands.BrandID=Cars.BrandID) As SourceTable Pivot (Sum(Amount) For PricingID In ([4],[5],[7])) as PivotTable;";
				command.CommandType = System.Data.CommandType.Text;
				_context.Database.OpenConnection();
				using (var reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						CarPricingViewModel carPricingViewModel = new CarPricingViewModel()
						{
							Brand = reader["BrandName"].ToString(),
							Model = reader["Model"].ToString(),
							CoverImageURL = reader["CoverImageUrl"].ToString(),
							Amounts = new List<decimal>
							{
								Convert.ToDecimal(reader["4"]),
								Convert.ToDecimal(reader["5"]),
								Convert.ToDecimal(reader["7"])
							}
						};
						values.Add(carPricingViewModel);
					}
				}
				_context.Database.CloseConnection();
				return values;
			}
		}
	}
}




//List<CarPricing> values = new List<CarPricing>();
//using (var command = _context.Database.GetDbConnection().CreateCommand())
//{
//	command.CommandText = "select * from (Select Brands.BrandName, Model,PricingID,Amount From CarPricings inner join Cars On Cars.CarID=CarPricings.CarID Inner join Brands On Brands.BrandID=Cars.BrandID ) As SourceTable Pivot( Sum(Amount) For PricingID In ([4],[5],[7]) ) as PivotTable;";
//	command.CommandType = System.Data.CommandType.Text;
//	using (var reader = command.ExecuteReader())
//	{
//		while (reader.Read())
//		{
//			CarPricing carPricing = new CarPricing();
//			Enumerable.Range(1, 3).ToList().ForEach(x =>
//			{
//				if (DBNull.Value.Equals(reader[x]))
//				{
//					carPricing.
//							}
//				else
//				{
//					carPricing.Amount
//							}
//			});
//			values.Add(carPricing);
//		}
//	}
//	_context.Database.CloseConnection();
//	return values;
//}


/*
			 var values = from x in _context.CarPricings
						 group x by x.PricingID into g
						 select new
						 {
							 CarID = g.Key,
							 DailyPrice = g.Where(y => y.CarPricingID == 4).Sum(z => z.Amount),
							 WeeklyPrice = g.Where(y => y.CarPricingID == 5).Sum(z => z.Amount),
							 MountlyPrice = g.Where(y => y.CarPricingID == 7).Sum(z => z.Amount)
						 };
			return values.ToList();     //values değerini liste olarak döndermedi // adonet sorgusu üzerinden göndermeyi denedik
			*/