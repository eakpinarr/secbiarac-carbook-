using CarBook.Application.Features.CQRS.Results.BlogResults;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandler
{
    public class GetLast5CarsWithBrandQueryHandler
    {
        private readonly ICarRepository _repository;

        public GetLast5CarsWithBrandQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }

        public  List<GetLast5CarsWithBrandQueryResult> Handle()
        {
           var values=_repository.GetLast5CarsWithBrands();
           return values.Select(x=>new GetLast5CarsWithBrandQueryResult 
            {
                BrandName=x.Brand.BrandName,
                BigImageURL = x.BigImageURL,
                BrandID = x.BrandID,
                CarID = x.CarID,
                CoverImageURL = x.CoverImageURL,
                Fuel = x.Fuel,
                Km = x.Km,
                Luggage = x.Luggage,
                Model = x.Model,
                seat = x.seat,
                Transmission = x.Transmission
            }).ToList();
        }
    }
}
