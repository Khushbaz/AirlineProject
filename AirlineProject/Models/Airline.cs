using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineProject.Models
{
    public class Airline
    {

        [Key]
        public int AirlineID { get; set; }

        public String AirlineName { get; set; }
       
        [DataType(DataType.Date)]
        public DateTime DepatureDate { get; set; }
      
    }
}
