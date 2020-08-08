using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data;

namespace Tracker.Models
{
    public class VolunteerEdit
    {
        public int VolunteerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public ICollection<DaysoftheWeek> DaysAbleToVolunteer { get; set; }
    }
}
