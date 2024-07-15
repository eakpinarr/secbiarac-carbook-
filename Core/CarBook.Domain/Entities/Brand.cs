using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class Brand
    {
        [Key]
        public int BrandID { get; set; }
        public string BrandName { get; set; }
        public List<Car> Cars { get; set; }

    }
}
