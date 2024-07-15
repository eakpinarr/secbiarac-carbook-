using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.DTO.CarDtos
{
    public class ResultLast5CarsWithBrandsDto
    {
        public int CarID { get; set; }
        public int BrandID { get; set; }
        public string Model { get; set; }
        public string CoverImageURL { get; set; }
        public int Km { get; set; }
        public string Transmission { get; set; }
        public byte seat { get; set; }
        public byte Luggage { get; set; }
        public string Fuel { get; set; }
        public string BigImageURL { get; set; }
        public string BrandName { get; set; }
    }
}
