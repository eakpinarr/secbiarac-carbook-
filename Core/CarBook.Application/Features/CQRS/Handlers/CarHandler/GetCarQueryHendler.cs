using CarBook.Application.Features.CQRS.Results.BlogResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandler
{
    public class GetCarQueryHendler
    {
        private readonly IRepository<Car> _repository;

        public GetCarQueryHendler(IRepository<Car> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetCarQueryResult>> Handle()
        {
            var values=await _repository.GetAllAsync();
            return values.Select(x=> new GetCarQueryResult
            { 
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
