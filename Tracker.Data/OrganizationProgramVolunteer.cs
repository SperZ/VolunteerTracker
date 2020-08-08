using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracker.Data
{
    public class OrganizationProgramVolunteer
    {
        public int OrganizationProgramVolunteerId { get; set; }
        public int OrganizationProgramId { get; set; }
        [ForeignKey(nameof(OrganizationProgramId))]
        public virtual OrganizationProgram OrganizationProgram { get; set; }

        public int VolunteerId { get; set; }
        [ForeignKey(nameof(VolunteerId))]
        public virtual Volunteer Volunteer { get; set; }
    }
}
