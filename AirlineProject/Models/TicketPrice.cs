using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineProject.Models
{
    public class TicketPrice
    {
        [Key]
        public int TicketID { get; set; }
        public string TicketName { get; set; }
        public int Price { get; set; }
        //Foreign Key
        public int AirlineID { get; set; }
        public Airline Airline_ID { get; set; }
    }
}
