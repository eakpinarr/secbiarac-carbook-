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
    public class GetCarWithBrandQueryHandler
    {
        private readonly ICarRepository _repository;

        public GetCarWithBrandQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }

        public  List<GetCarWithBrandQueryResult> Handle()
        {
           var values=_repository.GetCarWithBrands();
           return values.Select(x=>new GetCarWithBrandQueryResult
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
