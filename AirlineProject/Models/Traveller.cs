using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineProject.Models
{
    public class Traveller
    {
        [Key]
        public int TravellerID { get; set; }
        public string TravellerName { get; set; }
        public int ContactNumber { get; set; }
        
        //Foreign KeyI
        //public int HospitalID { get; set; }
        //public Hospital Hospital_obj { get; set; }
        //Foreign Key
        public int StaffMemberID { get; set; }
        public StaffMember StaffMember_ID { get; set; }
    }
}
