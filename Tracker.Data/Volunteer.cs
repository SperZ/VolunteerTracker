using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        public int RoleId { get; set; }
        [ForeignKey(nameof(RoleId))]
        public virtual ICollection<Role> Roles { get; set; }
        public ICollection<int> OrganizationId { get; set; }

        [ForeignKey(nameof(OrganizationId))]
        public virtual ICollection<Organization> Organization {get; set;}

        public ICollection<int> OrganizationProgramId { get; set; }

        [ForeignKey(nameof(OrganizationId))]
        public virtual ICollection<OrganizationProgram> OrganizationPrograms { get; set; }


    }
}
