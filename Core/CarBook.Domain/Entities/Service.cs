using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class Service
    {
        [Key]
        public int ServiceID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string IconURL { get; set; }

    }
}
