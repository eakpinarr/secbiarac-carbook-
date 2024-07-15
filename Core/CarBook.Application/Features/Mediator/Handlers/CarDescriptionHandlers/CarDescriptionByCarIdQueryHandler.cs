using CarBook.Application.Features.Mediator.Queries.CarDescriptionQueries;
using CarBook.Application.Features.Mediator.Results.CarDescriptionResults;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.CarDescriptionInderfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CarDescriptionHandlers
{
    public class CarDescriptionByCarIdQueryHandler:IRequestHandler<CarDescriptionByCarIdQuery, CarDescriptionQueryResult>
    {
        private readonly ICarDescriptionRepository _repository;

        public CarDescriptionByCarIdQueryHandler(ICarDescriptionRepository repository)
        {
            _repository = repository;
        }

        public async Task<CarDescriptionQueryResult> Handle(CarDescriptionByCarIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetCarDescription(request.Id);
            return new CarDescriptionQueryResult
            {
                CarDescriptionID=values.CarDescriptionID,
                CarID=values.CarID,
                Details=values.Details
            };
        }
    }
}
