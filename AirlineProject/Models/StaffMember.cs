using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineProject.Models
{
    public class StaffMember
    {
        [Key]
        public int StaffMemberID { get; set; }
        public string EmailId { get; set; }
        public string StaffMemberName { get; set; }
        public int ContactNumber { get; set; }
        //Foreign Key
        public int AirlineID { get; set; }
        public Airline Airline_ID { get; set; }
    }
}
