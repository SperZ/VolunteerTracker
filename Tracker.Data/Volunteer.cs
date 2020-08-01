using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracker.Data
{
    public enum DaysoftheWeek 
    {
        Sunday =1,
        Monday,
        Tuseday,
        Wednesday,
        Thursday,
        Friday,
        Saturday
    }
    public class Volunteer
    {
        public Volunteer()
        {
            this.Organization = new HashSet<Organization>();
            this.Roles = new HashSet<Role>();
            this.OrganizationPrograms = new HashSet<OrganizationProgram>();
        }
        [Key]
        public int VolunteerId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public ICollection<DaysoftheWeek> DaysAbleToVolunteer { get; set; }

        public ICollection<Role> Roles { get; set; }
        public ICollection<Organization> Organization {get; set;}
        public ICollection<OrganizationProgram> OrganizationPrograms { get; set; }


    }
}
