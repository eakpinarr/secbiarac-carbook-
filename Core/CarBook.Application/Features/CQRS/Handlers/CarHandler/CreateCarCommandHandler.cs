using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandler
{
    public class CreateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;

        public CreateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateCarCommand command)
        {
            await _repository.CreateAsync(new Car
            {
                BigImageURL = command.BigImageURL,
                Fuel = command.Fuel,
                BrandID = command.BrandID,
                CoverImageURL = command.CoverImageURL,
                Luggage = command.Luggage,
                Model = command.Model,
                Km = command.Km,
                seat = command.seat,
                Transmission = command.Transmission
            });

        }
    }
}
