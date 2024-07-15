using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.StatisticsInterfaces;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.StatisticsRepositories
{
    public class StatisticsRepositories : IStatisticsRepository
    {
        private readonly CarBookContext _context;

        public StatisticsRepositories(CarBookContext context)
        {
            _context = context;
        }

        public string GetBlogTitleByMaxBlogComment()
        {
            //Select Top(1) BlogID, Count(*)  as 'Sayi' From Comments Group By BlogID Order By Sayi Desc

         var value= _context.Comments.GroupBy(x => x.BlogID).
                Select(y => new
                {
                    BlogID = y.Key,
                    Count = y.Count()
                }).OrderByDescending(z=>z.Count).Take(1).FirstOrDefault();
         string blogName=_context.Blogs.Where(x=>x.BlogID ==value.BlogID).Select(y=>y.Title).FirstOrDefault();
         return blogName;
        }

        public string GetBrandNameByMaxCar()
        {
            //Select Top(1) Brands.Name,Count(*) as 'ToplamArac' From Cars
            //Inner Join Brands
            //On
            //Cars.BrandID=Brands.BrandID
            //Group By Brands.Name
            //order By ToplamArac Desc

            var value= _context.Cars.GroupBy(x => x.BrandID).
                Select(y => new
                {
                    BrandID = y.Key,
                    Count = y.Count()
                }).OrderByDescending(z=>z.Count).Take(1).FirstOrDefault();
            string brandName=_context.Brands.Where(x=>x.BrandID==value.BrandID).Select(y=>y.BrandName).FirstOrDefault();
            return brandName;
        }

        public int GetCarCount()
        {
            var value=_context.Cars.Count();
            return value;
        }

        public int GetAuthorCount()
        {
            var value=_context.Authors.Count();
            return value;
        }
        
        public decimal GetAvgRentPriceForDaily()
        {
            //Select Avg(Amount) from CarPricings where PricingID=(Select PricingID From Pricings Where Name='Günlük')
            int id=_context.Pricings.Where(y=>y.Name=="Günlük").Select(z=>z.PricingID).FirstOrDefault();
            var value = _context.CarPricings.Where(w => w.PricingID == id).Average(x => x.Amount);
            return value;
        }

        public decimal GetAvgRentPriceForMonthly()
        {
            int id = _context.Pricings.Where(y => y.Name == "Aylık").Select(z => z.PricingID).FirstOrDefault();
            var value = _context.CarPricings.Where(w => w.PricingID == id).Average(x => x.Amount);
            return value;
        }

        public decimal GetAvgRentPriceForWeekly()
        {
            int id = _context.Pricings.Where(y => y.Name == "Haftalık").Select(z => z.PricingID).FirstOrDefault();
            var value = _context.CarPricings.Where(w => w.PricingID == id).Average(x => x.Amount);
            return value;
        }

        public int GetBlogCount()
        {
            var value=_context.Blogs.Count();
            return value;
        }

        public string GetCarBrandAndModelByRentPriceDailyMax()
        {
            //Select * From CarPricings Where Amount=(Select Max(Amount) From CarPricings Where PricingID=5)
            int pricingID = _context.Pricings.Where(x => x.Name == "Günlük").Select(y => y.PricingID).FirstOrDefault();
            decimal amount = _context.CarPricings.Where(y => y.PricingID == pricingID).Max(x => x.Amount);
            int carID = _context.CarPricings.Where(x => x.Amount == amount).Select(y => y.CarID).FirstOrDefault();
            string brandModel = _context.Cars.Where(x => x.CarID == carID).Include(y => y.Brand).Select(z => z.Brand.BrandName + " " + z.Model).FirstOrDefault();
            return brandModel;  
        }

        public string GetCarBrandAndModelByRentPriceDailyMin()
        {
            //Select * From CarPricings Where Amount=(Select Max(Amount) From CarPricings Where PricingID=5)
            int pricingID = _context.Pricings.Where(x => x.Name == "Günlük").Select(y => y.PricingID).FirstOrDefault();
            decimal amount = _context.CarPricings.Where(y => y.PricingID == pricingID).Min(x => x.Amount);
            int carID = _context.CarPricings.Where(x => x.Amount == amount).Select(y => y.CarID).FirstOrDefault();
            string brandModel = _context.Cars.Where(x => x.CarID == carID).Include(y => y.Brand).Select(z => z.Brand.BrandName + " " + z.Model).FirstOrDefault();
            return brandModel;
        }

        public int GetCarCountByFuelElectric()
        {
            var value = _context.Cars.Where(x => x.Fuel == "Elektrik").Count();
            return value;
        }

        public int GetCarCountByFuelGasolineOrDiesel()
        {
            var value = _context.Cars.Where(x => x.Fuel == "Benzin" || x.Fuel == "Dizel").Count();
            return value;
        }

        public int GetCarCountByKmSmallerThen1000()
        {
            var value=_context.Cars.Where(x=>x.Km<=1000).Count();
            return value;
        }

        public int GetCarCountByTransmissionIsAuto()
        {
            var value = _context.Cars.Where(x => x.Transmission == "Otomatik").Count();
            return value;
        }

        public int GetLocationCount()
        {
            var value = _context.Locations.Count();
            return value;
        }

        public int GetBrandCount()
        {
            var value=_context.Brands.Count();
            return value;
        }
    }
}
