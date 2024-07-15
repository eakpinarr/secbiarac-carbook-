using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.CarDescriptionInderfaces
{
    public interface ICarDescriptionRepository
    {
        Task<CarDescription> GetCarDescription(int carId);
    }
}
