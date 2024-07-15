using CarBook.Application.Features.CQRS.Queries.CarQueries;
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
    public class GetCarByIdQueryHandler
    {
        private readonly IRepository<Car> _repository;

        public GetCarByIdQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }
        public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery query)
        {
            var vaules = await _repository.GetByIdAsync(query.Id);
            return new GetCarByIdQueryResult
            {
                CarID = vaules.CarID,
                BigImageURL = vaules.BigImageURL,
                BrandID = vaules.BrandID,
                CoverImageURL = vaules.CoverImageURL,
                Fuel = vaules.Fuel,
                Km = vaules.Km,
                Luggage = vaules.Luggage,
                Model = vaules.Model,
                seat = vaules.seat,
                Transmission = vaules.Transmission,
            };
        }
    }
}
