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
    public class UpdateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;

        public UpdateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateCarCommand command)
        {
            var values = await _repository.GetByIdAsync(command.CarID);
            values.CarID = command.CarID;
            values.Transmission= command.Transmission;
            values.CoverImageURL = command.CoverImageURL;
            values.Km= command.Km;
            values.Fuel= command.Fuel;
            values.seat= command.seat;
            values.Luggage= command.Luggage;
            values.Model= command.Model;
            values.BigImageURL = command.BigImageURL;
            await _repository.UpdateAsync(values);
        }
    }
}
