﻿using CarBook.Application.Interfaces.CarDescriptionInderfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.CarDescriptionRepositories
{
    public class CarDescriptionRepository : ICarDescriptionRepository
    {
        private readonly CarBookContext _context;

        public CarDescriptionRepository(CarBookContext context)
        {
            _context = context;
        }

        async Task<CarDescription> ICarDescriptionRepository.GetCarDescription(int carId)
        {
            var values = await _context.CarDescriptions.Where(x => x.CarID == carId).FirstOrDefaultAsync();
            return values;
        }
    }
}
