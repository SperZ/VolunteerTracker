using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracker.Data
{
    public class OrganizationVolunteer
    {
        public int OrganizationVolunteerId { get; set; }
        public int OrganizationId { get; set; }
        [ForeignKey(nameof(OrganizationId))]
        public virtual Organization Organization { get; set; }
        public int VolunteerId { get; set; }
        [ForeignKey(nameof(VolunteerId))]
        public virtual Volunteer Volunteer { get; set; }
    }
}
