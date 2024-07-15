﻿using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.CarInterfaces
{
    public interface ICarRepository
    {
        List<Car> GetCarWithBrands();
        List<Car> GetLast5CarsWithBrands();
        int GetCarCount();
    }
}
